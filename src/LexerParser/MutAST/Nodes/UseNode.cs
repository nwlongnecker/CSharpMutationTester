using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class UseNode : MutASTNode
    {
        public List<string> FileGlobs { get; }

        public UseNode(List<string> fileGlobs)
        {
            FileGlobs = fileGlobs;
        }
    }
}
