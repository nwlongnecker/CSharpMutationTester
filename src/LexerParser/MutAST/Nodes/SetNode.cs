using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class SetNode : MutASTNode
    {
        public FileType SetType { get; }
        public List<string> FileGlobs { get; }

        public SetNode(FileType setType, List<string> fileGlobs)
        {
            SetType = setType;
            FileGlobs = fileGlobs;
        }
    }
}
