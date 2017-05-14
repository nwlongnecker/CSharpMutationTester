using System;
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

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
