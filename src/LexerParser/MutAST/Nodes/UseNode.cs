using System;
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

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as UseNode;
            if (other == null) { return false; }
            return ListsAreEqual(FileGlobs, other.FileGlobs);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "FileGlobs", StringifyList(FileGlobs) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
