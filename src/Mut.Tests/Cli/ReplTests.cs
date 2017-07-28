using Mut.Cli;
using Interpreter.Log;
using NUnit.Framework;
using System;
using System.IO;

namespace Mut.Tests.Cli
{
    class ReplTests
    {
        private StringWriter _output;
        private Repl _repl;

        [SetUp]
        public void SetUp()
        {
            _output = new StringWriter();
            _repl = new Repl(Console.In, new Output(_output));
        }

        [Test]
        public void Repl_PromptsWhenCalled()
        {
            Assert.NotNull(_repl);
        }
    }
}
