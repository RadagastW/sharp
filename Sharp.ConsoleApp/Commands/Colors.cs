using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с цветом текста в консоли.
    /// </summary>
    public class Colors : ICommand
    {

        /// <summary>
        /// Выполнить команду для работы с цветом текста в консоли.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\n\"Цвет текста.\"\n");

            PrintMessageWithColor("Цвет текста: по умолчанию.");
            PrintMessageWithColor("красный", ConsoleColor.Red, "Цвет текста: ", ".");
            PrintMessageWithColor("синий", ConsoleColor.Blue, "Цвет текста: ", ".");

            Console.WriteLine();
            Console.ReadKey();
        }

        private static void PrintMessageWithColor(string message, ConsoleColor? color = null, string prefix = "", string suffix = "")
        {
            ConsoleColor defaultColor = Console.ForegroundColor;

            Console.Write(prefix);
            if (color != null)
            {
                Console.ForegroundColor = (ConsoleColor)color;
            }
            Console.Write(message);
            Console.ForegroundColor = defaultColor;
            Console.Write(suffix);
            Console.WriteLine();
        }
    }
}