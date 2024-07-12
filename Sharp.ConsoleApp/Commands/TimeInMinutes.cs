using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для отображения времени в часах и минутах.
    /// </summary>
    public class TimeInMinutes : ICommand
    {
        private const int TIME_IN_MINUTES = 130;

        /// <summary>
        /// Выполнить команду вывода времени в часах и минутах.
        /// </summary>
        public void Execute()
        {
            int hour = TIME_IN_MINUTES / 60;
            int minute = TIME_IN_MINUTES % 60;

            Console.WriteLine($"Время в минутах: {TIME_IN_MINUTES}, часы: {hour}, минуты: {minute}");
        }
    }
}