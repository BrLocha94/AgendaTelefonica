using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Commands.Models
{
    public class RemoveContactCommand : CommandBase
    {
        protected string name = string.Empty;

        public RemoveContactCommand(Agenda agenda) : base("Remover contato\n")
        {
            Callback = () =>
            {
                agenda.RemoveContact(name);
            };
        }

        public override void Execute()
        {
            Console.WriteLine("\nInforme o nome do contato:");
            name = Console.ReadLine();

            Callback?.Invoke();
        }
    }
}
