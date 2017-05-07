using Mut.Cli;
using NUnit.Framework;

namespace Mut.Tests.Interpreter
{
    class CommandVisitorTests
    {
        [Test]
        public void VisitTest_OneFile_CreatesActionWithOneFile()
        {
            var action = ExpressionEvaluator.SingleEval("test: myFile.txt");

            Assert.AreEqual("ActionList(SetTestAction(GetFileListAction(myFile.txt)))", action.ToString());
        }
    }
}
