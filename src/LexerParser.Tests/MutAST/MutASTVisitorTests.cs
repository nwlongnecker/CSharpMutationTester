using static LexerParser.LexParse.CommandToMutAST;
using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;
using NUnit.Framework;
using System.Collections.Generic;

namespace LexerParser.Tests.MutAST
{
    class MutASTVisitorTests
    {
        [Test]
        public void TestWhitespace_CorrectTree()
        {
            var ast = Transform(" ");
            Assert.AreEqual(new NoopNode(), ast);
        }

        [Test]
        public void TestListSource_CorrectTree()
        {
            var ast = Transform("list source");
            Assert.AreEqual(new ListNode(FileType.SOURCE), ast);
        }

        [Test]
        public void TestListTest_CorrectTree()
        {
            var ast = Transform("list test");
            Assert.AreEqual(new ListNode(FileType.TEST), ast);
        }

        [Test]
        public void TestReportLast_CorrectTree()
        {
            var ast = Transform("report last");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.LAST, new List<string>()), ast);
        }

        [Test]
        public void TestReportAll_CorrectTree()
        {
            var ast = Transform("report all");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, new List<string>()), ast);
        }

        [Test]
        public void TestReport_CorrectTree()
        {
            var ast = Transform("report");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, new List<string>()), ast);
        }

        [Test]
        public void TestReportFileList_CorrectTree()
        {
            var ast = Transform("report src/*,*.cs");
            var fileGlob = new List<string> { "src/*", "*.cs" };
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, fileGlob), ast);
        }

        [Test]
        public void SetSourceFileList_CorrectTree()
        {
            var ast = Transform("source: .\\src/*/*.cs");
            var fileGlob = new List<string> { ".\\src/*/*.cs" };
            Assert.AreEqual(new SetNode(FileType.SOURCE, fileGlob), ast);
        }

        [Test]
        public void SetTestFileList_CorrectTree()
        {
            var ast = Transform("test: .\\test/*/*Test.cs");
            var fileGlob = new List<string> { ".\\test/*/*Test.cs" };
            Assert.AreEqual(new SetNode(FileType.TEST, fileGlob), ast);
        }

        [Test]
        public void UseFileList_CorrectTree()
        {
            var ast = Transform("use strains/*,*.mut");
            var fileGlob = new List<string> { "strains/*", "*.mut" };
            Assert.AreEqual(new UseNode(fileGlob), ast);
        }

        [Test]
        public void AddSourceFileList_CorrectTree()
        {
            var ast = Transform("add source \"src.cs\",'src2.js'");
            var fileGlob = new List<string> { "\"src.cs\"", "'src2.js'" };
            Assert.AreEqual(new AddNode(FileType.SOURCE, fileGlob), ast);
        }

        [Test]
        public void AddTestFileList_CorrectTree()
        {
            var ast = Transform("add test \"tst.cs\",'tst2.js'");
            var fileGlob = new List<string> { "\"tst.cs\"", "'tst2.js'" };
            Assert.AreEqual(new AddNode(FileType.TEST, fileGlob), ast);
        }

        [Test]
        public void RemoveSourceFileList_CorrectTree()
        {
            var ast = Transform("remove source \"src.cs\",'src2.js'");
            var fileGlob = new List<string> { "\"src.cs\"", "'src2.js'" };
            Assert.AreEqual(new RemoveNode(FileType.SOURCE, fileGlob), ast);
        }

        [Test]
        public void RemoveTestFileList_CorrectTree()
        {
            var ast = Transform("remove test \"tst.cs\",'tst2.js'");
            var fileGlob = new List<string> { "\"tst.cs\"", "'tst2.js'" };
            Assert.AreEqual(new RemoveNode(FileType.TEST, fileGlob), ast);
        }

        [Test]
        public void MutateIdList_CorrectTree()
        {
            var ast = Transform("mutate id1,id2,a,b,c");
            var moduleIds = new List<string> { "id1", "id2", "a", "b", "c" };
            Assert.AreEqual(new MutateModulesNode(moduleIds), ast);
        }

        [Test]
        public void MutateIDMutatablesToOtherMutatables_CorrectTree()
        {
            var ast = Transform("mutate a23 to b23");
            var mutateFromSymbols = new List<string> { "a23" };
            var mutateToSymbols = new List<string> { "b23" };
            Assert.AreEqual(new MutateNode(mutateFromSymbols, mutateToSymbols), ast);
        }

        [Test]
        public void MutateFileMutatablesToOtherMutatables_CorrectTree()
        {
            var ast = Transform("mutate \"a23\" to 'b23'");
            var mutateFromSymbols = new List<string> { "\"a23\"" };
            var mutateToSymbols = new List<string> { "'b23'" };
            Assert.AreEqual(new MutateNode(mutateFromSymbols, mutateToSymbols), ast);
        }

        [Test]
        public void MutateSymbolMutatablesToOtherMutatables_CorrectTree()
        {
            var ast = Transform("mutate ++,'--' to \"++\",--");
            var mutateFromSymbols = new List<string> { "++", "'--'" };
            var mutateToSymbols = new List<string> { "\"++\"", "--" };
            Assert.AreEqual(new MutateNode(mutateFromSymbols, mutateToSymbols), ast);
        }

        [Test]
        public void Module_CorrectTree()
        {
            var ast = Transform("module asdf mutate ++,'--' to \"++\",-- end");
            var mutateFromSymbols = new List<string> { "++", "'--'" };
            var mutateToSymbols = new List<string> { "\"++\"", "--" };
            var mutateNodes = new List<MutASTNode> {
                new MutateNode(mutateFromSymbols, mutateToSymbols)
            };
            var moduleNode = new ModuleNode("asdf", mutateNodes);
            Assert.AreEqual(moduleNode, ast);
        }

        [Test]
        public void ModuleMutlipleMutations_CorrectTree()
        {
            var ast = Transform("module asdf2 mutate ++,'--' to \"++\",-- mutate a,b,c end");
            var mutateFromSymbols = new List<string> { "++", "'--'" };
            var mutateToSymbols = new List<string> { "\"++\"", "--" };
            var mutateIds = new List<string> { "a", "b", "c" };
            var mutateNodes = new List<MutASTNode> {
                new MutateNode(mutateFromSymbols, mutateToSymbols),
                new MutateModulesNode(mutateIds)
            };
            var moduleNode = new ModuleNode("asdf2", mutateNodes);
            Assert.AreEqual(moduleNode, ast);
        }

        [Test]
        public void MutFileMutlipleCommands_CorrectTree()
        {
            var mutFileText = "add test \"tst.cs\",'tst2.js' list test";
            var parser = BuildParser(mutFileText);
            var tree = parser.mutFile();
            var ast = tree.Accept(new MutASTCreatorVisitor());

            var fileGlob = new List<string> { "\"tst.cs\"", "'tst2.js'" };
            var addCommand = new AddNode(FileType.TEST, fileGlob);
            var listCommand = new ListNode(FileType.TEST);
            var commandList = new List<MutASTNode> { addCommand, listCommand };
            var mutFile = new MutFileNode(commandList);
            Assert.AreEqual(mutFile, ast);
        }
    }
}
