using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaTelefonica.Models;
using AgendaTelefonica.Utils;
using AgendaTelefonica.Commands;
using AgendaTelefonica.Commands.Models;

namespace AgendaTelefonica
{
    class Program
    {
        private static bool loop = true;
        private const string DATA_FILE_PATH = @"../Data.json";

        private const string CONSOLE_MESSAGE_WELCOME = "Bem vindo a sua agenda telefônica!\n";
        private const string CONSOLE_MESSAGE_COMMANDS = "\nInsira um dos seguintes comandos:\n";
        private const string CONSOLE_MESSAGE_INVALID = "Comando inválido:\n\n";
        private const string CONSOLE_MESSAGE_SAVING = "Salvando agenda e finalizando programa\n";
        private const string CONSOLE_MESSAGE_FINISH = "Agenda salva, pressione qualquer botão para finalizar\n";

        static void Main(string[] args)
        {
            Console.Write(CONSOLE_MESSAGE_WELCOME);

            Agenda agenda = new Agenda();
            JsonHandler.UpdateSerializedObject(DATA_FILE_PATH, agenda);

            CommandStack.AddCommand(new ListAllContactsCommand(agenda));
            CommandStack.AddCommand(new AddContactCommand(agenda));
            CommandStack.AddCommand(new SearchContactCommand(agenda));
            CommandStack.AddCommand(new RemoveContactCommand(agenda));
            CommandStack.AddCommand(new FinishProgramCommand(() => loop = false));

            while (loop)
            {
                Console.Write(CONSOLE_MESSAGE_COMMANDS);

                Console.Write(CommandStack.ListCommandsTags());

                string line = Console.ReadLine();

                int input;
                bool isNumeric = int.TryParse(line, out input);

                if (isNumeric)
                    CommandStack.ExecuteCommand(input);
                else
                    Console.Write(CONSOLE_MESSAGE_INVALID);
            }

            Console.Write(CONSOLE_MESSAGE_SAVING);
            JsonHandler.WriteSerializedInfo(DATA_FILE_PATH, agenda);
            Console.Write(CONSOLE_MESSAGE_FINISH);

            Console.ReadLine();
        }

    }
}
