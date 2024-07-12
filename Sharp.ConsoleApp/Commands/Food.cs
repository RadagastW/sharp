using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для вычисления возможности покупки еды за монеты.
    /// </summary>
    public class Food : ICommand
    {
        private const int FOOD_UNIT_PRICE = 10;

        /// <summary>
        /// Выполнить команду вычисления возможности покупки еды за монеты.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine($"Добро пожаловать в пекарню. Сегодня еда по {FOOD_UNIT_PRICE} монет.");
            int money = ConsoleUtilites.ReadFromConsole<int>("Сколько у вас золота? ");
            int food = ConsoleUtilites.ReadFromConsole<int>("Сколько еды вам нужно? ");

            bool isAbleToPay = money >= food * FOOD_UNIT_PRICE;
            food *= Convert.ToInt32(isAbleToPay);
            money -= food * FOOD_UNIT_PRICE;

            Console.WriteLine($"У вас в сумке {food} едениц еды и {money} монет.");
        }
    }
}