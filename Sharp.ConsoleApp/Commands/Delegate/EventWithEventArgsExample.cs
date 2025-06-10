using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Delegate
{
    /// <summary>
    /// Команда для работы с событиями (с передачей данных).
    /// </summary>
    public class EventWithEventArgsExample : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с событиями (с передачей данных).
        /// </summary>
        public void Execute()
        {
            DemonstrateEvents();

            WaitForUserInput();
        }

        private void DemonstrateEvents()
        {
            Console.WriteLine("\"Передача данных события\"\n");

            Account3 account = new Account3(0);

            account.Notify += DisplayMessage;
            account.Put(1000);
            account.Take(2000);
        }

        private void WaitForUserInput()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }

        private void DisplayMessage(Account3 sender, AccountEventArgs e)
        {
            Console.WriteLine($"Сумма транзакции: {e.Sum}");
            Console.WriteLine(e.Message);
            Console.WriteLine($"Текущая сумма на счете: {sender.Sum}");
        }
    }
}