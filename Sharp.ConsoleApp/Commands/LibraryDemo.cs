using Sharp.ClassLibrary;
using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для использования библиотеки классов.
    /// </summary>
    public class LibraryDemo : ICommand
    {
        /// <summary>
        /// Выполнить команду для использования библиотеки классов.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Library Demo\"\n");

            Person person = new Person("Name");
            person.Print();

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}