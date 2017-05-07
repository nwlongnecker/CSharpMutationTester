using System.Collections.Generic;
using System.Text;

namespace Mut.Interpreter.Actions
{
    class MutActionBase
    {
        List<object> arguments;
        public MutActionBase(params object[] args)
        {
            arguments = new List<object>(args);
        }

        public virtual bool Execute()
        {
            return true;
        }

        public override string ToString()
        {
            var builder = new StringBuilder(GetType().Name);
            builder.Append(' ');
            foreach(var argument in arguments)
            {
                builder.Append(argument.ToString());
                builder.Append(' ');
            }
            return builder.ToString().TrimEnd();
        }
    }
}
