using Sharp.ConsoleApp.Configuration;
using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;
using System.Windows.Forms;

namespace Sharp.ConsoleApp
{
    internal class Program
    {
        /// <summary>
        /// Основная точка входа в приложение.
        /// </summary>
        static void Main()
        {
            // Проверка наличия второго монитора
            if (Screen.AllScreens.Length > 1)
            {
                // Если второй монитор существует, перемещаем окно консоли на него
                ConsoleWindowManager.SetPosition(-1500, 50);
            }

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