using Sharp.ConsoleApp.Configuration;
using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для отображения списка доступных команд.
    /// </summary>
    public class Help : ICommand
    {
        /// <summary>
        /// Выполнить команду вывода списка доступных команд.
        /// </summary>
        public void Execute()
        {
            Dictionary<string, ICommand> commands = CommandFactory.GetCommands();

            Console.WriteLine("Список доступных команд:");

            foreach (var commandKey in commands.Keys)
            {
                Console.WriteLine($" - {commandKey}");
            }
        }
    }
}