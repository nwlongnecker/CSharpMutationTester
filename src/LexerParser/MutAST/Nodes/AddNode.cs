using System;
using System.Collections.Generic;

namespace MutDSL.MutAST.Nodes
{
    public class AddNode : MutASTNode
    {
        public FileType AddType { get; }
        public List<string> FileGlobs { get; }

        public AddNode(FileType addType, List<string> fileGlobs)
        {
            AddType = addType;
            FileGlobs = fileGlobs;
        }

        public override T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override bool Equals(object obj)
        {
            var other = obj as AddNode;
            if (other == null) { return false; }
            return AddType.Equals(other.AddType) && ListsAreEqual(FileGlobs, other.FileGlobs);
        }

        public override string ToString()
        {
            var properties = new Dictionary<string, string>
            {
                { "AddType", AddType.ToString() },
                { "FileGlobs", StringifyList(FileGlobs) }
            };
            return StringifyValues(GetType().ToString(), properties);
        }
    }
}
