using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Commands.Models
{
    public class SearchContactCommand : CommandBase
    {
        protected string name = string.Empty;
        protected string response = string.Empty;

        public SearchContactCommand(Agenda agenda) : base("Buscar contato\n")
        {
            Callback = () =>
            {
                Contact target = agenda.SearchContact(name);
                response = (target != null) ? target.ToString() : "Cant find contact named " + name;
            };
        }

        public override void Execute()
        {
            Console.WriteLine("\nInforme o nome do contato:");
            name = Console.ReadLine();

            Callback?.Invoke();

            Console.WriteLine(response);
        }
    }
}
