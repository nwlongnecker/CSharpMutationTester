using LexerParser.LexParse;
using static LexerParser.LexParse.CommandToMutASTConverter;
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
                BuildParser("source: myfile.txt").command();
            });
        }
    }
}
