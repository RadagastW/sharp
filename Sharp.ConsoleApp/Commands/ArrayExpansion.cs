using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для...
    /// </summary>
    public class ArrayExpansion : ICommand
    {
        /// <summary>
        /// Выполнить команду для расширения массива.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\n\"Расширение массива\"\n");

            char[] bag = new char[1];
            bag[0] = 'A';

            char[] tempBag = new char[bag.Length + 1];
            for (int i = 0; i < bag.Length; i++)
            {
                tempBag[i] = bag[i];
            }

            tempBag[tempBag.Length - 1] = 'B';

            bag = tempBag;

            for (int i = 0; i < bag.Length; i++)
            {
                Console.WriteLine($"№{i + 1}: {bag[i]}");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}