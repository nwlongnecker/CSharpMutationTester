using LexerParser.LexParse;
using MutDSL.MutAST.Nodes;
using NUnit.Framework;

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
            Assert.AreEqual(new ListSourceNode(), ast);
        }

        [Test]
        public void TestListTest_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("list test");
            Assert.AreEqual(new ListTestNode(), ast);
        }

        [Test]
        public void TestReportLast_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report last");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.LAST), ast);
        }

        [Test]
        public void TestReportAll_CorrectTree()
        {
            var ast = CommandToMutASTConverter.Convert("report all");
            Assert.AreEqual(new ReportNode(ReportNode.ReportType.ALL), ast);
        }
    }
}
