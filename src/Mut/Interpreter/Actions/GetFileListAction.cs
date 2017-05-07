using System.Collections.Generic;
using System.Text;

namespace Mut.Interpreter.Actions
{
    class GetFileListAction : MutActionBase
    {
        private IList<string> _filenames;
        private IList<string> _symbols;
        public GetFileListAction(IList<string> filenames, IList<string> symbols)
        {
            _filenames = filenames;
            _symbols = symbols;
        }

        public override string ToString()
        {
            var builder = new StringBuilder(GetType().Name);
            builder.Append('(');
            foreach (var filename in _filenames)
            {
                builder.Append(filename);
                builder.Append(',');
            }
            foreach (var symbol in _symbols)
            {
                builder.Append(symbol);
                builder.Append(',');
            }
            if (_filenames.Count > 0 || _symbols.Count > 0)
            {
                builder.Remove(builder.Length - 1, 1);
            }
            builder.Append(')');
            return builder.ToString().TrimEnd();
        }
    }
}
