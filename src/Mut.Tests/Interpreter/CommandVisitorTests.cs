using Mut.Interpreter;
using NUnit.Framework;

namespace Mut.Tests.Interpreter
{
    class CommandVisitorTests
    {
        private CommandVisitor _commandVisitor;
        [SetUp]
        public void Setup()
        {
            _commandVisitor = new CommandVisitor(null);

        }

        [Test]
        public void VisitTest_NoFiles_CreatesEmptyAction()
        {
            var testNode = new MutatorParser.TestContext(null, 0);
            var action = _commandVisitor.VisitTest(testNode);

            Assert.AreEqual(action.ToString(), "TestAction");
        }

        [Test]
        [Ignore("Revisiting testing strategy")]
        public void VisitTest_OneFile_CreatesActionWithOneFile()
        {
            var testNode = new MutatorParser.TestContext(null, 0);
            var fileNode = new MutatorParser.FileListContext(testNode, 0);
            testNode.AddChild(fileNode);
            var action = _commandVisitor.VisitTest(testNode);

            Assert.AreEqual(action.ToString(), "TestAction myFile");
        }
    }
}
