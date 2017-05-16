using Interpreter.State;
using MutDSL.MutAST.Nodes;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using System.Linq;

namespace Interpreter.Tests.State
{
    class MutASTVisitorTests
    {
        public static readonly string BASE_DIR = "C:\\TestDir";
        public static readonly string SOURCE_FILE = BASE_DIR + "\\Source.cs";
        public static readonly string TEST_FILE = BASE_DIR + "\\SourceTests.cs";
        public static readonly string SOURCE_DIR = BASE_DIR + "\\src";
        public static readonly string SOURCE_FILE1 = SOURCE_DIR + "\\Source1.cs";
        public static readonly string SOURCE_FILE2 = SOURCE_DIR + "\\OtherFile.cs";
        public static readonly string TEST_DIR = BASE_DIR + "\\tst";
        public static readonly string TEST_FILE1 = TEST_DIR + "\\Test1.cs";
        public static readonly string TEST_FILE2 = TEST_DIR + "\\OtherFile.cs";

        private MutASTVisitor visitor;
        private InterpreterState state;
        private IFileSystem fileSystem;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            fileSystem = new MockFileSystem();

            fileSystem.Directory.CreateDirectory(BASE_DIR);
            fileSystem.Directory.CreateDirectory(SOURCE_DIR);
            fileSystem.Directory.CreateDirectory(TEST_DIR);
            fileSystem.File.Create(SOURCE_FILE);
            fileSystem.File.Create(TEST_FILE);
            fileSystem.File.Create(SOURCE_FILE1);
            fileSystem.File.Create(SOURCE_FILE2);
            fileSystem.File.Create(TEST_FILE1);
            fileSystem.File.Create(TEST_FILE2);
        }

        [SetUp]
        public void SetUp()
        {
            state = new InterpreterState();
            visitor = new MutASTVisitor(state, fileSystem);
        }

        [Test]
        public void AddSourceFile_UpdatesState()
        {
            var files = new List<string> { SOURCE_FILE };
            var node = new AddNode(FileType.SOURCE, files);
            Assert.True(node.Accept(visitor), "Expected visitor to be successful");
            Assert.True(files.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(files, state.SourceFiles));
        }

        [Test]
        public void AddSourceFilesWithGlob_UpdatesState()
        {
            var files = new List<string> { SOURCE_DIR + "*1.cs" };
            var node = new AddNode(FileType.SOURCE, files);
            var expandedFiles = new List<string> { SOURCE_FILE1 };
            Assert.True(node.Accept(visitor), "Expected visitor to be successful");
            Assert.True(expandedFiles.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(expandedFiles, state.SourceFiles));
        }

        [Test]
        public void AddSourceFileAlreadyAdded_NoDuplicate()
        {
            state.SourceFiles = new List<string> { SOURCE_FILE };
            var files = new List<string> { SOURCE_FILE };
            var node = new AddNode(FileType.SOURCE, files);
            // Visitor should return false if any of the files were not added
            Assert.False(node.Accept(visitor), "Expected visitor to be unsuccessful");
            Assert.True(files.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(files, state.SourceFiles));
        }

        [Test]
        public void AddSourceFilesAlreadyAdded_NoDuplicate()
        {
            state.SourceFiles = new List<string> { SOURCE_FILE1 };
            var files = new List<string> { SOURCE_FILE1, SOURCE_FILE2 };
            var node = new AddNode(FileType.SOURCE, files);
            var expandedFiles = new List<string> { SOURCE_FILE1, SOURCE_FILE2 };
            // Visitor should return false if any of the files were not added
            Assert.False(node.Accept(visitor), "Expected visitor to be unsuccessful");
            Assert.True(expandedFiles.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(expandedFiles, state.SourceFiles));
        }

        [Test]
        [Ignore("Temp, currently refactoring")]
        public void AddSourceDirsWithGlob_UpdatesState()
        {
            var files = new List<string> { BASE_DIR + "*" };
            var node = new AddNode(FileType.SOURCE, files);
            var expandedFiles = new List<string> { SOURCE_FILE, TEST_FILE, SOURCE_FILE2, SOURCE_FILE1, TEST_FILE2, TEST_FILE1 };
            Assert.True(node.Accept(visitor), "Expected visitor to be successful");
            Assert.True(expandedFiles.SequenceEqual(state.SourceFiles), ExpectedEqualSequencesMessage(expandedFiles, state.SourceFiles));
        }

        private string ExpectedEqualSequencesMessage(IEnumerable<string> expected, IEnumerable<string> actual)
        {
            return "Expected sequences to be equal. Expected: [" + string.Join(",", expected) + "] Actual: [" + string.Join(",", actual) + "]";
        }
    }
}
