using Mut.Cli;
using Interpreter.Log;
using NUnit.Framework;
using System.IO;

namespace Mut.Tests.Cli
{
    [TestFixture]
    public class MutatorMainTests
    {
        private StringWriter _output;

        [SetUp]
        public void SetUp()
        {
            _output = new StringWriter();
            MutatorMain.Output = new Output(_output);
        }

        [Test]
        [Ignore("Calling Repl creates an infinite loop.")]
        public void StartProgram_NoArguments_StartsReplMode()
        {
            MutatorMain.Main(new string[0]);
            Assert.AreEqual(_output.ToString(), "Welcome to Mut, the Mutator DSL!\r\n");
        }

        [Test]
        public void StartProgram_Arguments_StartsScriptMode()
        {
            MutatorMain.Main(new string[] { "scriptName" });
            Assert.AreEqual(_output.ToString(), "Executing script scriptName\r\n");
        }
    }
}
