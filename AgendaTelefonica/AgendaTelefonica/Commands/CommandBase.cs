using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Commands
{
    public abstract class CommandBase
    {
        protected Action Callback = null;

        public string Tag { get; private set; }

        public CommandBase(string tag)
        {
            Tag = tag;
        }

        public abstract void Execute();
    }
}
