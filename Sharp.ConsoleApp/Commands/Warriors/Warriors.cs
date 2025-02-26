using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Warriors
{
    /// <summary>
    /// Команда для...
    /// </summary>
    public class Warriors : ICommand
    {
        /// <summary>
        /// Выполнить команду для Warriors.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Warriors\"\n");

            Knight warrior1 = new Knight(100, 10);
            Barbarian warrior2 = new Barbarian(100, 1, 7, 2);

            warrior1.TakeDamage(500);
            warrior2.TakeDamage(250);

            warrior1.ShowInfo();
            warrior2.ShowInfo();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}