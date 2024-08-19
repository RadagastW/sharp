using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для расчета депозита.
    /// </summary>
    public class Deposit : ICommand
    {
        /// <summary>
        /// Выполнить команду для расчета депозита.
        /// </summary>
        public void Execute()
        {
            float money = ConsoleUtilites.ReadFromConsole<float>("Введите количество денежных средств на счету: ");
            int years = ConsoleUtilites.ReadFromConsole<int>("На сколько лет открыт вклад: ");
            float persent = ConsoleUtilites.ReadFromConsole<float>("Под какой процент открыт вклад: ");

            for (int i = 0; i < years; i++)
            {
                money += money * persent / 100;
                Console.WriteLine($"В {i} году у вас {money} денежных средств.");
            }
        }
    }
}