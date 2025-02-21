using System;

namespace Sharp.ConsoleApp.Utilities
{
    public static class ConsoleUtilites
    {
        /// <summary>
        /// Считывает значение указанного типа из консоли, запрашивая пользователя, пока не будет введено корректное значение.
        /// </summary>
        /// <typeparam name="T">Тип значения, которое необходимо считать из консоли. Должен реализовывать IConvertible.</typeparam>
        /// <param name="prompt">Сообщение для запроса ввода, отображаемое пользователю.</param>
        /// <returns>Значение типа <typeparamref name="T"/>, считанное из консоли.</returns>
        /// <remarks>
        /// Этот метод будет повторно запрашивать пользователя до тех пор, пока не будет введено корректное значение. 
        /// Для преобразования строки в указанный тип <typeparamref name="T"/> используется метод <see cref="Convert.ChangeType"/>.
        /// </remarks>
        public static T ReadFromConsole<T>(string prompt)
            where T : IConvertible
        {
            T value;

            while (true)
            {
                Console.Write($"{prompt}");

                string input = Console.ReadLine();
                try
                {
                    value = (T)Convert.ChangeType(input, typeof(T));
                    break;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите правильное число.");
                }
            }

            return value;
        }

        /// <summary>
        /// Ограничивает значение в заданном диапазоне.
        /// </summary>
        /// <param name="value">Значение, которое необходимо ограничить.</param>
        /// <param name="min">Минимально допустимое значение.</param>
        /// <param name="max">Максимально допустимое значение.</param>
        /// <returns>Значение, ограниченное диапазоном от min до max.</returns>
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
    }
}