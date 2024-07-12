using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для вычисления оставшегося здоровья после удара.
    /// </summary>
    public class HealthCalculation : ICommand
    {
        private const int PERCENT_CONVERTER = 100;

        /// <summary>
        /// Выполнить команду вычисления оставшегося здоровья после удара.
        /// </summary>
        public void Execute()
        {
            int health = ReadIntFromConsole("Введите кол-во здоровья");
            int armor = ReadIntFromConsole("Введите кол-во брони");
            int damage = ReadIntFromConsole("Введите кол-во урона");

            health -= damage * armor / PERCENT_CONVERTER;

            Console.WriteLine($"Вам нанесли {damage} урона. У вас осталось {health} здоровья.");
        }

        /// <summary>
        /// Запрашивает у пользователя ввод целого числа. Повторяет запрос до тех пор, пока не будет введено корректное значение.
        /// </summary>
        /// <param name="prompt">Сообщение для запроса ввода, отображаемое пользователю.</param>
        /// <returns>Целочисленное значение, введенное пользователем.</returns>
        private int ReadIntFromConsole(string prompt)
        {
            int value;

            while (true)
            {
                Console.Write($"{prompt}: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите правильное число.");
                }
            }

            return value;
        }
    }
}