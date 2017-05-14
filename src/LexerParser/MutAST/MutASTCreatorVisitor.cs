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
            var addType = FileType.SOURCE;
            if (context.TEST() != null)
            {
                addType = FileType.TEST;
            }
            return new AddNode(addType, GetFileGlobList(context.fileList()));
        }

        public MutASTNode VisitChildren(IRuleNode node)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitCommand([NotNull] MutatorParser.CommandContext context)
        {
            // Command should never have more than one child. The lexer should split such input into separate commands.
            return context.GetChild(0).Accept(this);
        }

        public MutASTNode VisitErrorNode(IErrorNode node)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitFileList([NotNull] MutatorParser.FileListContext context)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitIdList([NotNull] MutatorParser.IdListContext context)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitList([NotNull] MutatorParser.ListContext context)
        {
            var listType = FileType.SOURCE;
            if (context.TEST() != null)
            {
                listType = FileType.TEST;
            }
            return new ListNode(listType);
        }

        public MutASTNode VisitModule([NotNull] MutatorParser.ModuleContext context)
        {
            var id = context.ID().GetText();
            var mutations = context.mutate();
            var mutationList = new List<MutASTNode>();
            foreach(var mutation in mutations)
            {
                mutationList.Add(mutation.Accept(this));
            }
            return new ModuleNode(id, mutationList);
        }

        public MutASTNode VisitMutatable([NotNull] MutatorParser.MutatableContext context)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitMutate([NotNull] MutatorParser.MutateContext context)
        {
            var ids = context.idList();
            if (ids != null)
            {
                var idList = new List<string>();
                foreach (var id in ids.ID())
                {
                    idList.Add(id.GetText());
                }
                return new MutateModulesNode(idList);
            }
            // mutatables will always have a length of 2
            var mutatables = context.mutatable();
            var mutateFromList = GetMutatableList(mutatables[0]);
            var mutateToList = GetMutatableList(mutatables[1]);
            return new MutateNode(mutateFromList, mutateToList);
        }

        public MutASTNode VisitMutFile([NotNull] MutatorParser.MutFileContext context)
        {
            var commands = context.command();
            var commandList = new List<MutASTNode>();
            foreach(var command in commands)
            {
                commandList.Add(command.Accept(this));
            }
            return new MutFileNode(commandList);
        }

        public MutASTNode VisitRemove([NotNull] MutatorParser.RemoveContext context)
        {
            var addType = FileType.SOURCE;
            if (context.TEST() != null)
            {
                addType = FileType.TEST;
            }
            return new RemoveNode(addType, GetFileGlobList(context.fileList()));
        }

        public MutASTNode VisitReport([NotNull] MutatorParser.ReportContext context)
        {
            // Default to reporting all tests
            var reportType = ReportNode.ReportType.ALL;
            if (context.LAST() != null)
            {
                reportType = ReportNode.ReportType.LAST;
            }
            var fileGlobList = GetFileGlobList(context.fileList());
            return new ReportNode(reportType, fileGlobList);
        }

        public MutASTNode VisitSet([NotNull] MutatorParser.SetContext context)
        {
            var fileGlobList = GetFileGlobList(context.fileList());
            var setType = FileType.SOURCE;
            if (context.TEST() != null)
            {
                setType = FileType.TEST;
            }
            return new SetNode(setType, fileGlobList);
        }

        public MutASTNode VisitSymbolList([NotNull] MutatorParser.SymbolListContext context)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitTerminal(ITerminalNode node)
        {
            throw new NotImplementedException("Should never be called");
        }

        public MutASTNode VisitUse([NotNull] MutatorParser.UseContext context)
        {
            return new UseNode(GetFileGlobList(context.fileList()));
        }

        private List<string> GetFileGlobList(MutatorParser.FileListContext context)
        {
            var fileGlobList = new List<string>();
            if (context != null)
            {
                foreach (var fileglob in context.FILEGLOB())
                {
                    fileGlobList.Add(fileglob.GetText());
                }
            }
            return fileGlobList;
        }

        private List<string> GetMutatableList(MutatorParser.MutatableContext context)
        {
            var mutatableList = new List<string>();
            var idList = context.idList();
            var fileList = context.fileList();
            var symbolList = context.symbolList();
            if (idList != null)
            {
                foreach (var id in idList.ID())
                {
                    mutatableList.Add(id.GetText());
                }
            }
            else if (fileList != null)
            {
                foreach (var fileGlob in fileList.FILEGLOB())
                {
                    mutatableList.Add(fileGlob.GetText());
                }
            }
            else if (symbolList != null)
            {
                foreach (var symbol in symbolList.SYMBOL())
                {
                    mutatableList.Add(symbol.GetText());
                }
            }
            return mutatableList;
        }
    }
}
