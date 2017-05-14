using System;

namespace MutDSL.MutAST.Nodes
{
    public class NoopNode : MutASTNode
    {
        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            throw new NotImplementedException();
        }
    }
}
