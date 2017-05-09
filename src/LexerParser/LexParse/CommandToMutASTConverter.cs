using Antlr4.Runtime;
using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;

namespace LexerParser.LexParse
{
    public class CommandToMutASTConverter
    {
        public static MutASTNode Convert(string command, IMutatorVisitor<MutASTNode> visitor = null)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return new NoopNode();
            }
            visitor = visitor ?? new MutASTCreatorVisitor();
            var lexer = new MutatorLexer(new AntlrInputStream(command));
            lexer.AddErrorListener(new MutLexerErrorListener());
            var parser = new MutatorParser(new CommonTokenStream(lexer));
            parser.AddErrorListener(new MutParserErrorListener());
            var tree = parser.command();
            return tree.Accept(visitor);
        }
    }
}
