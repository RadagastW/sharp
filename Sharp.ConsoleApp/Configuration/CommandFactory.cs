using Sharp.ConsoleApp.Commands;
using Sharp.ConsoleApp.Interfaces;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Configuration
{
    /// <summary>
    /// Фабрика команд, предоставляющая доступ к экземплярам команд.
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Получить словарь команд.
        /// </summary>
        /// <returns>Словарь, где ключ - имя команды, значение - экземпляр команды.</returns>
        public static Dictionary<string, ICommand> GetCommands()
        {
            return new Dictionary<string, ICommand>
            {
                { "HELP", new Help() },
                { "CURRENCY_EXCHANGE", new CurrencyExchange() },
                { "DEPOSIT", new Deposit() },
                { "FOOD", new Food() },
                { "GLADIATORS", new Gladiators() },
                { "GUESS", new Guess() },
                { "HEALTH_CALCULATION", new HealthCalculation() },
                { "PASSWORD", new Password() },
                { "TIME_IN_MINUTES", new TimeInMinutes() },
                { "EXIT", new Exit() }
            };
        }
    }
}