using System;
using System.Runtime.Serialization;

namespace Mut.Cli
{
    [Serializable]
    internal class MutatorParserException : Exception
    {
        public MutatorParserException()
        {
        }

        public MutatorParserException(string message) : base(message)
        {
        }

        public MutatorParserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MutatorParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}