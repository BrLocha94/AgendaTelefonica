using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Commands.Models
{
    public class ListAllContactsCommand : CommandBase
    {
        protected string response = string.Empty;

        public ListAllContactsCommand(Agenda agenda) : base("Listar agenda completa\n")
        {
            Callback = () =>
            {
                response = agenda.ToString();
            };
        }

        public override void Execute()
        {
            Callback?.Invoke();

            Console.WriteLine(response);
        }
    }
}
