using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с коллекцией Stack.
    /// </summary>
    public class Stacks : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с коллекцией Stack.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Коллекция Stack\"");

            Stack<int> numbers = new Stack<int>();

            numbers.Push(ConsoleUtilites.ReadFromConsole<int>("Введите 1 число: "));
            numbers.Push(ConsoleUtilites.ReadFromConsole<int>("Введите 2 число: "));
            numbers.Push(ConsoleUtilites.ReadFromConsole<int>("Введите 3 число: "));
            numbers.Push(ConsoleUtilites.ReadFromConsole<int>("Введите 4 число: "));
            numbers.Push(ConsoleUtilites.ReadFromConsole<int>("Введите 5 число: "));

            Console.WriteLine($"Последнее введенное число: {numbers.Peek()}.");

            while (numbers.Count > 0)
            {
                Console.WriteLine($"Извлекаемый элемент: {numbers.Pop()}.");
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}