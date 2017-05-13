using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using LexerParser.LexParse;
using MutDSL.MutAST.Nodes;
using System;
using System.Collections.Generic;

namespace MutDSL.MutAST
{
    class MutASTCreatorVisitor : IMutatorVisitor<MutASTNode>
    {
        public MutASTNode Visit(IParseTree tree)
        {
            throw new NotImplementedException("Behavior has not been defined for this node");
        }

        public MutASTNode VisitAdd([NotNull] MutatorParser.AddContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitCommand([NotNull] MutatorParser.CommandContext context)
        {
            // Command should never have more than one child. The lexer should split such input into separate commands.
            return context.GetChild(0).Accept(this);
        }

        public MutASTNode VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitFileList([NotNull] MutatorParser.FileListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitIdList([NotNull] MutatorParser.IdListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitList([NotNull] MutatorParser.ListContext context)
        {
            var listType = ListNode.ListType.SOURCE;
            if (context.TEST() != null)
            {
                listType = ListNode.ListType.TEST;
            }
            return new ListNode(listType);
        }

        public MutASTNode VisitMutatable([NotNull] MutatorParser.MutatableContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitMutate([NotNull] MutatorParser.MutateContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitMutFile([NotNull] MutatorParser.MutFileContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitRemove([NotNull] MutatorParser.RemoveContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitReport([NotNull] MutatorParser.ReportContext context)
        {
            // Default to reporting all tests
            var reportType = ReportNode.ReportType.ALL;
            if (context.LAST() != null)
            {
                reportType = ReportNode.ReportType.LAST;
            }
            var fileGlobList = new List<string>();
            var fileContext = context.fileList();
            if (fileContext != null)
            {
                foreach (var fileglob in fileContext.FILEGLOB())
                {
                    fileGlobList.Add(fileglob.GetText());
                }
            }
            return new ReportNode(reportType, fileGlobList);
        }

        public MutASTNode VisitSource([NotNull] MutatorParser.SourceContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitStrain([NotNull] MutatorParser.StrainContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitSymbolList([NotNull] MutatorParser.SymbolListContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitTest([NotNull] MutatorParser.TestContext context)
        {
            throw new NotImplementedException();
        }

        public MutASTNode VisitUse([NotNull] MutatorParser.UseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
