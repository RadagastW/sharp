using Sharp.ConsoleApp.Interfaces;
using System;
using System.Linq;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с одномерным массивом.
    /// </summary>
    public class Arrays : ICommand
    {
        private Random _rand = new Random();

        /// <summary>
        /// Выполнить команду для работы с одномерным массивом.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Одномерный массив.");

            int[] array = new int[10];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = _rand.Next(-100, 101);
            }

            Console.WriteLine($"Индексы: \t{string.Join("\t", Enumerable.Range(0, array.Length))}.");
            Console.WriteLine($"Значения: \t{string.Join("\t", array)}.");
            Console.WriteLine($"Минимальный элемент: \t{array.Min()}.");
            Console.WriteLine($"Максимальный элемент: \t{array.Max()}.");
        }
    }
}