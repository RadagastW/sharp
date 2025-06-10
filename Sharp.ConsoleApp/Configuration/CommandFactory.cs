using Sharp.ConsoleApp.Commands;
using Sharp.ConsoleApp.Commands.Behaviors;
using Sharp.ConsoleApp.Commands.Booking;
using Sharp.ConsoleApp.Commands.Delegate;
using Sharp.ConsoleApp.Commands.Encapsulation;
using Sharp.ConsoleApp.Commands.Enum;
using Sharp.ConsoleApp.Commands.Fighters;
using Sharp.ConsoleApp.Commands.Generic;
using Sharp.ConsoleApp.Commands.LINQ;
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
                { "CLUB", new ComputerClubManager() },
                { "COLORS", new Colors() },
                { "CURRENCY_EXCHANGE", new CurrencyExchange() },
                { "DELEGATE", new DelegateExample() },
                { "DEPOSIT", new Deposit() },
                { "DICTIONARIES", new Dictionaries() },
                { "ENCAPSULATION", new Encapsulation() },
                { "ENUM", new EnumManager() },
                { "EVENT", new EventExample() },
                { "FIGHTERS", new Fighters() },
                { "FOOD", new Food() },
                { "GENERIC", new GenericArrayExample() },
                { "GLADIATORS", new Gladiators() },
                { "GUESS", new Guess() },
                { "HEALTH_CALCULATION", new HealthCalculation() },
                { "HEALTHBAR", new HealthBar() },
                { "LIBRARY", new Library() },
                { "LIBRARY_DEMO", new LibraryDemo() },
                { "LINQ", new LinqExamples() },
                { "LISTS", new Lists() },
                { "PACKMAN", new Packman() },
                { "PASSWORD", new Password() },
                { "QUEUES", new Queues() },
                { "REGISTRATION", new Registration() },
                { "RENDER", new Render() },
                { "RESIZE", new Resize() },
                { "STACKS", new Stacks() },
                { "TASKSBOARD", new TasksBoard() },
                { "TEMPLATE", new Template() },
                { "TIME_IN_MINUTES", new TimeInMinutes() },
                { "WALKER", new WalkerGame() },
                { "WARRIORS", new Warriors() },
                { "EXIT", new Exit() }
            };
        }
    }
}