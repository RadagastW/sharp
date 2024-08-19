using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для ввода пароля.
    /// </summary>
    public class Password : ICommand
    {
        private const int MAX_TRIES = 5;
        private const string CORRECT_PASSWORD = "qwerty";

        /// <summary>
        /// Выполнить команду для ввода пароля.
        /// </summary>
        public void Execute()
        {
            for (int attempt = 1; attempt < MAX_TRIES; attempt++)
            {
                Console.Write($"Введите пароль: ");
                string input = Console.ReadLine();

                if (input == CORRECT_PASSWORD)
                {
                    Console.WriteLine("Введен верный пароль.");
                    return;
                }
                else
                {
                    Console.WriteLine("Введен неверный пароль.");

                    int remainingTries = MAX_TRIES - attempt;

                    if (remainingTries > 0)
                    {
                        Console.WriteLine($"Осталось попыток: {remainingTries}");
                    }
                    else
                    {
                        Console.WriteLine("Закончились попытки ввода.");
                    }
                }
            }
        }
    }
}