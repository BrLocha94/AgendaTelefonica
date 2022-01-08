using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Commands.Models
{
    public class AddContactCommand : CommandBase
    {
        protected string name = string.Empty;
        protected string phone = string.Empty;
        protected string adress = string.Empty;
        protected string relation = string.Empty;

        public AddContactCommand(Agenda agenda) : base("Adicionar/Alterar contato\n")
        {
            Callback = () =>
            {
                agenda.AddContact(name, phone, adress, relation);
            };
        }

        public override void Execute()
        {
            Console.WriteLine("\nInforme o nome do contato:");
            name = Console.ReadLine();

            Console.WriteLine("Informe o telefone do contato:");
            phone = Console.ReadLine();

            Console.WriteLine("Informe o endereço do contato:");
            adress = Console.ReadLine();

            Console.WriteLine("Informe a relação do contato:");
            relation = Console.ReadLine();

            Callback?.Invoke();
        }
    }
}
