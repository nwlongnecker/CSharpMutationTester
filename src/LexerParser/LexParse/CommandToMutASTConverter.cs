using Antlr4.Runtime;
using MutDSL.MutAST;
using MutDSL.MutAST.Nodes;

namespace LexerParser.LexParse
{
    public class CommandToMutAST
    {
        public static MutASTNode Transform(string command, IMutatorVisitor<MutASTNode> visitor = null)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return new NoopNode();
            }
            visitor = visitor ?? new MutASTCreatorVisitor();
            var parser = BuildParser(command);
            var tree = parser.command();
            return tree.Accept(visitor);
        }

        internal static MutatorLexer BuildLexer(string command)
        {
            var lexer = new MutatorLexer(new AntlrInputStream(command));
            lexer.AddErrorListener(new MutLexerErrorListener());
            return lexer;
        }

        internal static MutatorParser BuildParser(string command)
        {
            var lexer = BuildLexer(command);
            var parser = new MutatorParser(new CommonTokenStream(lexer));
            parser.AddErrorListener(new MutParserErrorListener());
            return parser;
        }
    }
}
