using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
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
            int health = ConsoleUtilites.ReadIntFromConsole("Введите кол-во здоровья: ");
            int armor = ConsoleUtilites.ReadIntFromConsole("Введите кол-во брони: ");
            int damage = ConsoleUtilites.ReadIntFromConsole("Введите кол-во урона: ");

            health -= damage * armor / PERCENT_CONVERTER;

            Console.WriteLine($"Вам нанесли {damage} урона. У вас осталось {health} здоровья.");
        }
    }
}