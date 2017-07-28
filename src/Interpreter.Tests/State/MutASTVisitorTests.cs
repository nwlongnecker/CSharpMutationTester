using Interpreter.Log;
using Interpreter.State;
using MutDSL.MutAST.Nodes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Interpreter.Tests.State
{
    class MutASTVisitorTests
    {
        private static string TEST_DIR = AppDomain.CurrentDomain.BaseDirectory + "MutASTVisitorTestsTestDir";
        private static string SOURCE_FILE = TEST_DIR + "\\Source.cs";
        private static string TEST_FILE = TEST_DIR + "\\SourceTests.cs";

        private MutASTVisitor visitor;
        private InterpreterState state;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            // Ensure these files exist. Files will be cleaned up with binaries whenever clean is run.
            Directory.CreateDirectory(TEST_DIR);
            File.Create(SOURCE_FILE);
            File.Create(TEST_FILE);
        }

        [SetUp]
        public void SetUp()
        {
            state = new InterpreterState();
            visitor = new MutASTVisitor(state, new Output());
        }

        [Test]
        public void AddSourceFile_UpdatesState()
        {
            var files = new List<string> { SOURCE_FILE };
            var node = new AddNode(FileType.SOURCE, files);
            Assert.True(node.Accept(visitor));
            Assert.True(files.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(files, state.SourceFiles));
        }

        [Test, Ignore("Next test to work on")]
        public void AddSourceFilesWithGlob_UpdatesState()
        {
            var files = new List<string> { TEST_DIR + "*" };
            var node = new AddNode(FileType.SOURCE, files);
            Assert.True(node.Accept(visitor));
            Assert.True(files.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(files, state.SourceFiles));
        }

        private string ExpectedEqualSequencesMessage(IEnumerable<string> expected, IEnumerable<string> actual)
        {
            return "Expected sequences to be equal. Expected: [" + string.Join(",", expected) + "] Actual: [" + string.Join(",", actual) + "]";
        }
    }
}
