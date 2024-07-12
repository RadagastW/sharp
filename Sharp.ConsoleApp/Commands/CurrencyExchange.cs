using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для обмена валюты.
    /// </summary>
    public class CurrencyExchange : ICommand
    {
        private const int RUB_TO_USD = 64;
        private const int USD_TO_RUB = 66;

        /// <summary>
        /// Выполнить команду для обмена валюты.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Обмен валют.");

            float rublesInWallet = ConsoleUtilites.ReadFromConsole<float>("Введите баланс рублей: ");
            float dollarsInWallet = ConsoleUtilites.ReadFromConsole<float>("Введите баланс долларов: ");

            Console.WriteLine("Выберите необходимую операцию.");
            Console.WriteLine("1 - обменять рубли на доллары.");
            Console.WriteLine("2 - обменять доллары на рубли.");

            int desiredOperation = ConsoleUtilites.ReadFromConsole<int>("Ваш выбор: ");

            float exchangeCurrencyCount;

            switch (desiredOperation)
            {
                case 1:
                    Console.WriteLine("Обмен рублей на доллары.");
                    exchangeCurrencyCount = ConsoleUtilites.ReadFromConsole<float>("Сколько вы хотите обменять? ");
                    if (rublesInWallet >= exchangeCurrencyCount)
                    {
                        rublesInWallet -= exchangeCurrencyCount;
                        dollarsInWallet += exchangeCurrencyCount / RUB_TO_USD;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое количество рублей.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Обмен долларов на рубли.");
                    exchangeCurrencyCount = ConsoleUtilites.ReadFromConsole<float>("Сколько вы хотите обменять? ");
                    if (dollarsInWallet >= exchangeCurrencyCount)
                    {
                        dollarsInWallet -= exchangeCurrencyCount;
                        rublesInWallet += exchangeCurrencyCount * USD_TO_RUB;
                    }
                    else
                    {
                        Console.WriteLine("Недопустимое количество долларов.");
                    }
                    break;
                default:
                    Console.WriteLine("Выбрана неверная операция.");
                    break;
            }

            Console.WriteLine($"Ваш баланс: {rublesInWallet} рублей, {dollarsInWallet} долларов.");
        }
    }
}