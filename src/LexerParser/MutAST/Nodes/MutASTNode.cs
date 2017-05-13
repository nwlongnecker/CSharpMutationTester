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
            var isEqual = type.Equals(obj?.GetType());
            if (isEqual)
            {
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    if (!PropertiesAreEqual(property, obj))
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            return isEqual;
        }

        private bool PropertiesAreEqual(PropertyInfo property, object otherObject)
        {
            var myProperty = property.GetValue(this);
            var otherProperty = property.GetValue(otherObject);
            // If one is null, objects are not equal
            if (myProperty != null && otherProperty == null ||
                myProperty == null && otherProperty != null)
            {
                return false;
            }
            return myProperty.Equals(otherProperty) ||
                StringifyPropertyValue(myProperty).Equals(StringifyPropertyValue(otherProperty));
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
                    stringBuilder.Append(StringifyPropertyValue(property.GetValue(this)));
                    stringBuilder.Append(',');
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append('}');
            }
            return stringBuilder.ToString();
        }

        private string StringifyPropertyValue(object propertyValue)
        {
            var listValue = propertyValue as IList<string>;
            if (listValue != null)
            {
                return '[' + string.Join(",", listValue) + ']';
            }
            return propertyValue?.ToString();
        }
    }
}