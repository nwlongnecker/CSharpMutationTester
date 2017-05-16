using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class RemoveNode : MutASTNode
    {
        public FileType RemoveType { get; }
        public List<string> FileGlobs { get; }

        public RemoveNode(FileType removeType, List<string> fileGlobs)
        {
            RemoveType = removeType;
            FileGlobs = fileGlobs;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as RemoveNode;
            if (other == null) { return false; }
            return RemoveType.Equals(other.RemoveType) && ListsAreEqual(FileGlobs, other.FileGlobs);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "RemoveType", RemoveType.ToString() },
                { "FileGlobs", StringifyList(FileGlobs) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
