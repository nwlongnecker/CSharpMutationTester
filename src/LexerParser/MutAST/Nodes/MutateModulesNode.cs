using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class MutateModulesNode : MutASTNode
    {
        public List<string> ModuleIds { get; }

        public MutateModulesNode(List<string> moduleIds)
        {
            ModuleIds = moduleIds;
        }
    }
}
