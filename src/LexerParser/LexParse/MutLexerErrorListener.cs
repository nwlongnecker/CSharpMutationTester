using Antlr4.Runtime;
using System.IO;

namespace LexerParser.LexParse
{
    internal class MutLexerErrorListener : IAntlrErrorListener<int>
    {
        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new MutatorLexerException(msg, e);
        }
    }
}