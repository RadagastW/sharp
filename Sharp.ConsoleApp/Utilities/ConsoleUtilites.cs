using System;

namespace Sharp.ConsoleApp.Utilities
{
    public static class ConsoleUtilites
    {
        /// <summary>
        /// Запрашивает у пользователя ввод целого числа. Повторяет запрос до тех пор, пока не будет введено корректное значение.
        /// </summary>
        /// <param name="prompt">Сообщение для запроса ввода, отображаемое пользователю.</param>
        /// <returns>Целочисленное значение, введенное пользователем.</returns>
        public static int ReadIntFromConsole(string prompt)
        {
            int value;

            while (true)
            {
                Console.Write($"{prompt}");

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