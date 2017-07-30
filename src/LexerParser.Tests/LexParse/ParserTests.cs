using LexerParser.LexParse;
using static LexerParser.LexParse.CommandToMutAST;
using NUnit.Framework;

namespace LexerParser.Tests.LexParse
{
    class ParserTests
    {
        [Test]
        public void NonToken_Throws()
        {
            Assert.Throws<MutatorParserException>(() => {
                BuildParser("asdf").command();
            });
        }

        [Test]
        public void ValidTokenIncorrectPlace_Throws()
        {
            Assert.Throws<MutatorParserException>(() => {
                BuildParser(",").command();
            });
        }

        [Test]
        public void IncompleteCommand_Throws()
        {
            Assert.Throws<MutatorParserException>(() => {
                BuildParser("source").command();
            });
        }

        [Test]
        public void CompleteCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("set source myfile.txt").command();
            });
        }

        [Test]
        public void SourceCommandFileGlob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("set source .\\src\\*.cs").command();
            });
        }

        [Test]
        public void TestCommandQuotedFileGlob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("set test '.\\tests?\\*\\*Test.cs'").command();
            });
        }

        [Test]
        public void UseCommandQuotedFileGlob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("use \".\\mutations\\*.mut\"").command();
            });
        }

        [Test]
        public void AddSourceCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("add source source.cs").command();
            });
        }

        [Test]
        public void RemoveSourceCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("remove source *").command();
            });
        }

        [Test]
        public void AddTestCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("add test .\\test\\*/*Test.*").command();
            });
        }

        [Test]
        public void RemoveTestCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("remove test './tst/*'").command();
            });
        }

        [Test]
        public void ListSourceCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("list source").command();
            });
        }

        [Test]
        public void ListTestCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("list test").command();
            });
        }

        [Test]
        public void ListTestCommandWithArgument_Throws()
        {
            Assert.Throws<MutatorParserException>(() => {
                var parser = BuildParser("list test './tst/*'");
                parser.command();
                parser.command();
            });
        }

        [Test]
        public void MutateCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("mutate &&,^ to \"||\"").command();
            });
        }

        [Test]
        public void MutateStrainCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("mutate addition,subtraction").command();
            });
        }

        [Test]
        public void MutateCommandFileglob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("mutate 'a' to 'b'").command();
            });
        }

        [Test]
        public void MutateCommandIds_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("mutate a to b").command();
            });
        }

        [Test]
        public void ModuleCommandSymbols_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("module addition mutate + to - mutate * to % end").command();
            });
        }

        [Test]
        public void ReportCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report").command();
            });
        }

        [Test]
        public void ReportLastCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report last").command();
            });
        }

        [Test]
        public void ReportAllCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report all").command();
            });
        }

        [Test]
        public void ReportSurvivedCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report all survivied").command();
            });
        }

        [Test]
        public void ReportKilledCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report last killed").command();
            });
        }

        [Test]
        public void ReportStillbornCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report stillborn").command();
            });
        }

        [Test]
        public void ReportFileListCommand_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("report last '*.cs'").command();
            });
        }

        [Test]
        public void RelativePathFileGlob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("add source '.\\scripts\\Alias-Cake.ps1'").command();
            });
        }

        [Test]
        public void FullPathFileGlob_DoesNotThrow()
        {
            Assert.DoesNotThrow(() => {
                BuildParser("add source C:/a.txt").command();
            });
        }
    }
}
