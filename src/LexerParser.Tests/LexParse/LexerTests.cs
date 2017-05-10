using static LexerParser.LexParse.CommandToMutASTConverter;
using NUnit.Framework;
using System.Linq;

namespace LexerParser.Tests.LexParse
{
    class LexerTests
    {
        [Test]
        public void EmptyString_NoTokens()
        {
            var tokens = BuildLexer("").GetAllTokens();
            Assert.AreEqual(0, tokens.Count);
        }

        [Test]
        public void Comma_Lexes()
        {
            var tokens = BuildLexer(",").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.COMMA, tokens.First().Type);
        }

        [Test]
        public void Colon_Lexes()
        {
            var tokens = BuildLexer(":").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.COLON, tokens.First().Type);
        }

        [Test]
        public void Source_Lexes()
        {
            var tokens = BuildLexer("source").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.SOURCE, tokens.First().Type);
        }

        [Test]
        public void Test_Lexes()
        {
            var tokens = BuildLexer("test").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.TEST, tokens.First().Type);
        }

        [Test]
        public void Use_Lexes()
        {
            var tokens = BuildLexer("use").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.USE, tokens.First().Type);
        }

        [Test]
        public void Add_Lexes()
        {
            var tokens = BuildLexer("add").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.ADD, tokens.First().Type);
        }

        [Test]
        public void Remove_Lexes()
        {
            var tokens = BuildLexer("remove").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.REMOVE, tokens.First().Type);
        }

        [Test]
        public void List_Lexes()
        {
            var tokens = BuildLexer("list").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.LIST, tokens.First().Type);
        }

        [Test]
        public void Strain_Lexes()
        {
            var tokens = BuildLexer("strain").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.STRAIN, tokens.First().Type);
        }

        [Test]
        public void End_Lexes()
        {
            var tokens = BuildLexer("end").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.END, tokens.First().Type);
        }

        [Test]
        public void Mutate_Lexes()
        {
            var tokens = BuildLexer("mutate").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.MUTATE, tokens.First().Type);
        }

        [Test]
        public void To_Lexes()
        {
            var tokens = BuildLexer("to").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.TO, tokens.First().Type);
        }

        [Test]
        public void Report_Lexes()
        {
            var tokens = BuildLexer("report").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.REPORT, tokens.First().Type);
        }

        [Test]
        public void Last_Lexes()
        {
            var tokens = BuildLexer("last").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.LAST, tokens.First().Type);
        }

        [Test]
        public void All_Lexes()
        {
            var tokens = BuildLexer("all").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.ALL, tokens.First().Type);
        }

        [Test]
        public void Survived_Lexes()
        {
            var tokens = BuildLexer("survived").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.SURVIVED, tokens.First().Type);
        }

        [Test]
        public void Killed_Lexes()
        {
            var tokens = BuildLexer("killed").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.KILLED, tokens.First().Type);
        }

        [Test]
        public void Stillborn_Lexes()
        {
            var tokens = BuildLexer("stillborn").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.STILLBORN, tokens.First().Type);
        }

        [Test]
        public void Whitespace_DoesNotCountAsToken()
        {
            var tokens = BuildLexer("  \r\n\t").GetAllTokens();
            Assert.AreEqual(0, tokens.Count);
        }

        [Test]
        public void Comment_DoesNotCountAsToken()
        {
            var tokens = BuildLexer("#asdfsadf").GetAllTokens();
            Assert.AreEqual(0, tokens.Count);
        }

        [Test]
        public void Id_Lexes()
        {
            var tokens = BuildLexer("a23My_ID").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.ID, tokens.First().Type);
        }

        [Test]
        public void Filepath_Lexes()
        {
            var tokens = BuildLexer("mydir/myfile.txt").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void FilepathNoExtension_Lexes()
        {
            var tokens = BuildLexer("mydir/myfile").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void FilepathMutipleDirs_Lexes()
        {
            var tokens = BuildLexer("my_dir/mydir.2/my_file.txt").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void DoubleQuotedFilepath_Lexes()
        {
            var tokens = BuildLexer("\"my_dir/mydir.2/my_file.txt\"").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void DoubleQuotedFilepathSpaces_Lexes()
        {
            var tokens = BuildLexer("\"my_d r/myd r.2/my_f le.txt\"").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void SingleQuotedFilepathNoDirs_Lexes()
        {
            var tokens = BuildLexer("'myfile'").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void SingleQuotedFilepathNoDirsSpaces_Lexes()
        {
            var tokens = BuildLexer("'my file'").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void FilepathNoDirsNoExtension_LexesAsId()
        {
            var tokens = BuildLexer("hosts").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.ID, tokens.First().Type);
        }

        [Test]
        public void StartingWithNumber_LexesAsFilePath()
        {
            var tokens = BuildLexer("23My_NotID").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.FILEPATH, tokens.First().Type);
        }

        [Test]
        public void SymbolToken_Lexes()
        {
            var tokens = BuildLexer("%fasf").GetAllTokens();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(MutatorLexer.SYMBOL, tokens.First().Type);
        }
    }
}
