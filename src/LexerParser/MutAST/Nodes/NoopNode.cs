using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class NoopNode : MutASTNode
    {
        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var other = obj as NoopNode;
            return other != null;
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>();
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
