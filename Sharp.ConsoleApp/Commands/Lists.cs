using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с коллекцией List.
    /// </summary>
    public class Lists : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с коллекцией List.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Коллекция List\"");

            List<char> list = new List<char>() { 'a', 'b', 'c' };
            list.Add('d');
            list.AddRange(new List<char>() { 'e', 'f', 'g' });
            list.RemoveAt(0);
            list.Remove('f');
            list.Insert(4, 'z');

            Console.WriteLine($"Коллекция: {string.Join(", ", list)}.");
            Console.WriteLine($"Символ 'e' находится на позиции: {list.IndexOf('e')}.");

            list.Sort();
            Console.WriteLine($"Отсортированная коллекция: {string.Join(", ", list)}.");

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}