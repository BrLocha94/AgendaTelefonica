using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.Commands
{
    public static class CommandStack
    {
        public static List<CommandBase> commands = new List<CommandBase>();

        public static void AddCommand(CommandBase command)
        {
            commands.Add(command);
        }

        public static string ListCommandsTags()
        {
            string list = string.Empty;

            for(int i = 0; i < commands.Count; i++)
            {
                list += "   " + i + "- " + commands[i].Tag;
            }

            return list;
        }

        public static bool ExecuteCommand(int index)
        {
            if (index >= commands.Count)
                return false;

            commands[index].Execute();
            return true;
        }
    }
}
