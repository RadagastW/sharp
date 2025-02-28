using Sharp.ConsoleApp.Commands;
using Sharp.ConsoleApp.Commands.Behaviors;
using Sharp.ConsoleApp.Commands.Booking;
using Sharp.ConsoleApp.Commands.Encapsulation;
using Sharp.ConsoleApp.Commands.Fighters;
using Sharp.ConsoleApp.Commands.Packman;
using Sharp.ConsoleApp.Commands.Render;
using Sharp.ConsoleApp.Commands.TasksBoard;
using Sharp.ConsoleApp.Commands.Warriors;
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
                { "ARRAY_EXPANSION", new ArrayExpansion() },
                { "ARRAYS", new Arrays() },
                { "BEHAVIORS", new Behaviors() },
                { "BOOKING", new Booking() },
                { "COLORS", new Colors() },
                { "CURRENCY_EXCHANGE", new CurrencyExchange() },
                { "DEPOSIT", new Deposit() },
                { "DICTIONARIES", new Dictionaries() },
                { "ENCAPSULATION", new Encapsulation() },
                { "FIGHTERS", new Fighters() },
                { "FOOD", new Food() },
                { "GLADIATORS", new Gladiators() },
                { "GUESS", new Guess() },
                { "HEALTH_CALCULATION", new HealthCalculation() },
                { "HEALTHBAR", new HealthBar() },
                { "LIBRARY", new Library() },
                { "LISTS", new Lists() },
                { "PACKMAN", new Packman() },
                { "PASSWORD", new Password() },
                { "QUEUES", new Queues() },
                { "REGISTRATION", new Registration() },
                { "RENDER", new Render() },
                { "RESIZE", new Resize() },
                { "STACKS", new Stacks() },
                { "TASKSBOARD", new TasksBoard() },
                { "TEMPLATE", new Behaviors() },
                { "TIME_IN_MINUTES", new TimeInMinutes() },
                { "WALKER", new WalkerGame() },
                { "WARRIORS", new Warriors() },
                { "EXIT", new Exit() }
            };
        }
    }
}