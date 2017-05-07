using System;
using System.Runtime.Serialization;

namespace Mut.Cli
{
    [Serializable]
    internal class MutatorLexerException : Exception
    {
        public MutatorLexerException()
        {
        }

        public MutatorLexerException(string message) : base(message)
        {
        }

        public MutatorLexerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MutatorLexerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}