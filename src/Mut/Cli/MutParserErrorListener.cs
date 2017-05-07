using System.IO;
using Antlr4.Runtime;

namespace Mut.Cli
{
    internal class MutParserErrorListener : IAntlrErrorListener<IToken>
    {
        public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            throw new MutatorParserException(msg, e);
        }
    }
}