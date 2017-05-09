using MutDSL.MutAST.Nodes;
using System;

namespace MutDSL.MutAST
{
    public abstract class AbstractMutASTVisitor<T>
    {
        public T Visit(MutASTNode mutASTNode)
        {
            throw new NotImplementedException("Visit method not implemented on " + this.GetType() + " for " + mutASTNode.GetType());
        }
    }
}
