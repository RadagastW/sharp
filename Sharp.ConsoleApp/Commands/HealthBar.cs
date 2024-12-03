using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с HealthBar.
    /// </summary>
    public class HealthBar : ICommand
    {
        private const int MAX_HEALTH = 10;
        private const int MAX_MANA = 10;

        /// <summary>
        /// Выполнить команду для работы с HealthBar.
        /// </summary>
        public void Execute()
        {
            Console.Clear();

            int health = 5;
            int mana = 5;

            while (true)
            {
                DrawBar("Health", health, MAX_HEALTH, ConsoleColor.Green);
                DrawBar("Mana", mana, MAX_MANA, ConsoleColor.Blue, 90);

                Console.SetCursorPosition(0, 3);

                if (Math.Min(health, mana) <= 0)
                {
                    Console.WriteLine("Игра окончена!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
  
                health = UpdateValue(health, MAX_HEALTH, "Введите число, на которое изменяется жизнь: ");
                mana = UpdateValue(mana, MAX_MANA, "Введите число, на которое изменяется мана: ");

                Console.Clear();
            }
        }

        /// <summary>
        /// Рисует строку прогресса (полоску состояния).
        /// </summary>
        /// <param name="label">Название полоски (например, "Health" или "Mana").</param>
        /// <param name="value">Текущее значение полоски.</param>
        /// <param name="maxValue">Максимальное значение полоски.</param>
        /// <param name="color">Цвет полоски.</param>
        /// <param name="positionX">Начальная позиция по оси X на экране консоли.</param>
        /// <param name="positionY">Начальная позиция по оси Y на экране консоли.</param>
        /// <param name="symbol">Символ, используемый для заполнения полоски (по умолчанию '█').</param>
        private static void DrawBar(string label, int value, int maxValue, ConsoleColor color, int positionX = 0, int positionY = 0, char symbol = ' ')
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write($"{label}: [");
            int barLength = Math.Max(0, Math.Min(value, maxValue));
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.Write(new string(symbol, barLength));
            Console.BackgroundColor = defaultColor;
            Console.Write(new string(symbol, maxValue - barLength));
            Console.WriteLine($"] {value}/{maxValue}");
        }

        /// <summary>
        /// Обновляет текущее значение с учетом пользовательского ввода и ограничений.
        /// </summary>
        /// <param name="currentValue">Текущее значение параметра (например, здоровья или маны).</param>
        /// <param name="maxValue">Максимально допустимое значение параметра.</param>
        /// <param name="prompt">Сообщение, отображаемое пользователю для ввода.</param>
        /// <returns>Новое значение, ограниченное диапазоном от 0 до maxValue.</returns>
        private static int UpdateValue(int currentValue, int maxValue, string prompt)
        {
            int delta = ConsoleUtilites.ReadFromConsole<int>(prompt);
            return ConsoleUtilites.Clamp(currentValue + delta, 0, maxValue);
        }
    }
}