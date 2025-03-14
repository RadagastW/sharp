using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для для запуска приложения "Компьютерный клуб".
    /// </summary>
    public class ComputerClubManager : ICommand
    {
        /// <summary>
        /// Выполнить команду для запуска приложения "Компьютерный клуб".
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Компьютерный клуб\"\n");

            ComputerClub computerClub = new ComputerClub(5);
            computerClub.Work();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}