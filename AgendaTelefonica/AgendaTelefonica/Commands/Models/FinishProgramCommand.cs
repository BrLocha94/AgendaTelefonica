using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Commands.Models
{
    public class FinishProgramCommand : CommandBase
    {
        public FinishProgramCommand(Action finishProgramAction) : base("Finalizar programa\n")
        {
            Callback = finishProgramAction;
        }

        public override void Execute()
        {
            Callback?.Invoke();
        }
    }
}
