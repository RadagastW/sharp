using Sharp.ConsoleApp.Configuration;
using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        static void Main()
        {
            string input = "";

            while (input != "EXIT")
            {
                Console.Write("Введите команду: ");
                input = Console.ReadLine()?.ToUpper();

                if (input != null && CommandFactory.GetCommands().TryGetValue(input, out ICommand command))
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Введите HELP для получения списка команд.");
                }
            }
        }
    }
}