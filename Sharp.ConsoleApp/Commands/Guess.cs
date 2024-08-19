using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для игры "Угадай число".
    /// </summary>
    public class Guess : ICommand
    {
        private const int MAX_TRIES = 5;

        /// <summary>
        /// Выполнить команду для запуска игры "Угадай число".
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Угадай число\"");

            Random rand = new Random();

            int number = rand.Next(0, 101);
            int lower = rand.Next(number - 10, number);
            int higher = rand.Next(number + 1, number + 10);

            Console.WriteLine($"Было загадано число от 1 до 100, большее чем {lower} и меньшее чем {higher}.");
            Console.WriteLine($"Что это за число? У вас {MAX_TRIES} попыток отгадать.");

            for (int i = 1; i <= MAX_TRIES; i++)
            {
                int input = ConsoleUtilites.ReadFromConsole<int>("Ответ: ");

                if (input == number)
                {
                    Console.WriteLine("Верный ответ!");
                    return;
                }

                Console.WriteLine($"Неверный ответ!");

                if (i != MAX_TRIES)
                {
                    Console.WriteLine($"Осталось попыток: {MAX_TRIES - i}.");
                }
                else
                {
                    Console.WriteLine($"Вы проиграли. Это было число: {number}.");
                }
            }
        }
    }
}