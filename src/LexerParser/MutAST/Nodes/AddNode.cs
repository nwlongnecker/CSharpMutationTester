using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class AddNode : MutASTNode
    {
        public FileType AddType { get; }
        public List<string> FileGlobs { get; }

        public AddNode(FileType addType, List<string> fileGlobs)
        {
            AddType = addType;
            FileGlobs = fileGlobs;
        }
    }
}
