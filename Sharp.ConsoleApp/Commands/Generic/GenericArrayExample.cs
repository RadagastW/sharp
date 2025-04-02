using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands.Generic
{
    /// <summary>
    /// Команда для работы с обобщенными типами.
    /// </summary>
    public partial class GenericArrayExample : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с обобщенными типами.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Пример работы с обобщенными типами\"\n");

            int[] array = { 5, 7, 12 };

            GenericArray<int> genericArray = new GenericArray<int>(array);
            genericArray.ShowTypeArray();
            genericArray.ShowArray();
            genericArray.ShowElementAt(genericArray.GetLength() - 1);

            int element = ConsoleUtilites.ReadFromConsole<int>("Введите новый элемент: ");
            Console.WriteLine("\nРезультат после добавления элемента.");
            genericArray.AddElement(element);
            genericArray.ShowArray();

            Console.WriteLine("\nРезультат после удаления первого элемента.");
            genericArray.RemoveAt(0);
            genericArray.ShowArray();

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}