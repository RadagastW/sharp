using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Delegate.EventExample
{
    /// <summary>
    /// Команда для работы с событиями.
    /// </summary>
    public class EventExample : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с событиями.
        /// </summary>
        public void Execute()
        {
            DemonstrateEvents();

            WaitForUserInput();
        }

        private void DemonstrateEvents()
        {
            Console.WriteLine("\"Примеры работы с событиями\"\n");

            Account account = new Account(0);

            // Добавление обработчика для события Notify
            // Установка в качестве обработчика метода DisplayMessage
            account.Notify += DisplayMessage;
            account.Put(1000);

            account.Notify += DisplayRedMessage;
            account.Take(2000);

            // Добавление обработчика для события Notify
            // Установка в качестве обработчика делегата, который указывает на метод DisplayMessage
            account.Notify += new Account.AccountHandler(DisplayMessage);
            account.Put(100);

            // Добавление обработчика для события Notify
            // Установка в качестве обработчика анонимного метода
            account.Notify += delegate (string message)
            {
                Console.WriteLine(message);
            };
            account.Put(200);

            // Добавление обработчика для события Notify
            // Установка в качестве обработчика лямбда-выражения
            account.Notify += message => Console.WriteLine(message);
            account.Put(200);
        }

        private void WaitForUserInput()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }

        private void DisplayMessage(string message) => Console.WriteLine(message);

        private void DisplayRedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}