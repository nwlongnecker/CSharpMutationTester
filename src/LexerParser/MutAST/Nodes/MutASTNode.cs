using Antlr4.Runtime.Tree;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MutDSL.MutAST.Nodes
{
    public abstract class MutASTNode
    {
        public abstract T Accept<T>(AbstractMutASTVisitor<T> visitor);

        // Helper methods so it is easier to override Equals and ToString in subclasses
        protected bool ListsAreEqual(List<string> listOne, List<string> listTwo)
        {
            var equal = listOne.Count == listTwo.Count;
            if (equal) {
                for (var i = 0; i < listOne.Count; i++)
                {
                    equal = listOne[i].Equals(listTwo[i]) && equal;
                }
            }
            return equal;
        }

        protected bool ListsAreEqual(List<MutASTNode> listOne, List<MutASTNode> listTwo)
        {
            var equal = listOne.Count == listTwo.Count;
            if (equal)
            {
                for (var i = 0; i < listOne.Count; i++)
                {
                    equal = listOne[i].Equals(listTwo[i]) && equal;
                }
            }
            return equal;
        }

        protected string StringifyList(List<string> list)
        {
            return '[' + string.Join(",", list) + ']';
        }

        protected string StringifyList(List<MutASTNode> list)
        {
            return '[' + string.Join(",", list.SelectMany(node => node.ToString())) + ']';
        }

        protected string StringifyValues(string type, Dictionary<string, string> properties)
        {
            var stringBuilder = new StringBuilder(type.ToString());
            if (properties.Count > 0)
            {
                stringBuilder.Append('{');
                foreach (var property in properties)
                {
                    stringBuilder.Append(property.Key);
                    stringBuilder.Append(':');
                    stringBuilder.Append(property.Value);
                    stringBuilder.Append(',');
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append('}');
            }
            return stringBuilder.ToString();
        }
    }
}