using Antlr4.Runtime.Tree;
using System.Text;

namespace MutDSL.MutAST.Nodes
{
    public abstract class MutASTNode
    {
        public T Accept<T>(AbstractMutASTVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
        
        /// <summary>
        /// Use reflection to deep compare each of the public properties
        /// </summary>
        /// <param name="obj">Other object to compare to</param>
        /// <returns>Whether the object is equal to this one</returns>
        public override bool Equals(object obj)
        {
            var type = GetType();
            var isEqual = type.Equals(obj.GetType());
            if (isEqual)
            {
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    var myProperty = property.GetValue(this);
                    var otherProperty = property.GetValue(obj);
                    if (myProperty != null && !myProperty.Equals(otherProperty) ||
                        myProperty == null && otherProperty != null)
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            return isEqual;
        }

        /// <summary>
        /// Uses reflection to print the properties and values of the node in json-style format
        /// </summary>
        /// <returns>A string representation of the object and its properties</returns>
        public override string ToString()
        {
            var type = GetType();
            var properties = type.GetProperties();
            var stringBuilder = new StringBuilder(type.ToString());
            if (properties.Length > 0)
            {
                stringBuilder.Append('{');
                foreach(var property in properties)
                {
                    stringBuilder.Append(property.Name);
                    stringBuilder.Append(':');
                    stringBuilder.Append(property.GetValue(this));
                    stringBuilder.Append(',');
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append('}');
            }
            return stringBuilder.ToString();
        }
    }
}