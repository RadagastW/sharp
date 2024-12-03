using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с массивами разной длины.
    /// </summary>
    public class Resize : ICommand
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Выполнить команду для работы с массивами разной длины.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\n\"Смена размера массива.\"\n");

            int[] array = GenerateRandomeArray();
            PrintArray(array);

            array = ResizeArray(array);
            PrintArray(array);

            Console.WriteLine();
            Console.ReadKey();
        }

        /// <summary>
        /// Генерирует массив случайной длины со случайными элементами.
        /// </summary>
        /// <returns>Сгенерированный массив.</returns>
        private static int[] GenerateRandomeArray()
        {
            int arrayLength = _random.Next(1, 11);
            int[] array = new int[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                array[i] = _random.Next(1, 10);
            }

            return array;
        }

        /// <summary>
        /// Изменяет размер массива, добавляя случайные значения, если новый массив длиннее.
        /// </summary>
        /// <param name="array">Исходный массив.</param>
        /// <returns>Массив с измененной длиной.</returns>
        private static int[] ResizeArray(int[] array)
        {
            int newLength = _random.Next(1, 11);
            int[] resizedArray = new int[newLength];

            Array.Copy(array, resizedArray, Math.Min(array.Length, newLength));

            for (int i = array.Length; i < resizedArray.Length; i++)
            {
                resizedArray[i] = _random.Next(-9, -1);
            }

            return resizedArray;
        }

        /// <summary>
        /// Выводит массив в консоль.
        /// </summary>
        /// <param name="array">Массив для вывода.</param>
        private static void PrintArray(int[] array)
        {
            Console.WriteLine($"Размерность массива: {array.Length}.");
            Console.WriteLine(string.Join(" ", array));
        }
    }
}