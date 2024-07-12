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
                catch (FormatException)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите правильное число.");
                }
            }

            return value;
        }
    }
}