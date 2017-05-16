using System;
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

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as SetNode;
            if (other == null) { return false; }
            return SetType.Equals(other.SetType) && ListsAreEqual(FileGlobs, other.FileGlobs);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "SetType", SetType.ToString() },
                { "FileGlobs", StringifyList(FileGlobs) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
