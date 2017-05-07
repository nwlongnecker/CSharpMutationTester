using System.Collections.Generic;
using System.Text;

namespace Mut.Interpreter.Actions
{
    class MutActionBase
    {
        List<MutActionBase> arguments;
        public MutActionBase(params MutActionBase[] args)
        {
            arguments = new List<MutActionBase>(args);
        }

        public virtual ICollection<string> Execute()
        {
            return new List<string>();
        }

        public override string ToString()
        {
            var builder = new StringBuilder(GetType().Name);
            builder.Append('(');
            foreach(var argument in arguments)
            {
                builder.Append(argument.ToString());
                builder.Append(',');
            }
            if (arguments.Count > 0) {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append(')');
            return builder.ToString().TrimEnd();
        }
    }
}
