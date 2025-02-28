using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Behaviors
{
    /// <summary>
    /// Команда для запуска "Цикла обновления".
    /// </summary>
    public class Behaviors : ICommand
    {
        /// <summary>
        /// Выполнить команду для запуска "Цикла обновления".
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Цикл обновления\"\n");

            Behavior[] behaviors =
            {
                new Walker(),
                new Jumper()
            };

            // while (true)
            for (int i = 0; i < 10; i++)
            {
                foreach (var behavior in behaviors)
                {
                    behavior.Update();
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}