using LexerParser.LexParse;
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
            var ast = CommandToMutASTConverter.Convert(" ");
            Assert.AreEqual(new NoopNode(), ast);
        }

        [Test]
        public void TestListSource_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("list source");
            Assert.AreEqual(new ListNode(ListNode.ListType.SOURCE), ast);
        }

        [Test]
        public void TestListTest_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("list test");
            Assert.AreEqual(new ListNode(ListNode.ListType.TEST), ast);
        }

        [Test]
        public void TestReportLast_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report last");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.LAST, new List<string>()), ast);
        }

        [Test]
        public void TestReportAll_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report all");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, new List<string>()), ast);
        }

        [Test]
        public void TestReport_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, new List<string>()), ast);
        }

        [Test]
        public void TestReportFileList_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report src/*,*.cs");
            var fileGlob = new List<string> { "src/*", "*.cs" };
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL, fileGlob), ast);
        }
    }
}
