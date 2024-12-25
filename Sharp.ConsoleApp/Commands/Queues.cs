using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы с очередью Queue.
    /// </summary>
    public class Queues : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с очередью Queue.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Очередь Queue\"");

            Queue<string> patients = new Queue<string>();
            patients.Enqueue(ConsoleUtilites.ReadFromConsole<string>("Введите имя первого пациента: "));
            patients.Enqueue(ConsoleUtilites.ReadFromConsole<string>("Введите имя втрого пациента: "));
            patients.Enqueue(ConsoleUtilites.ReadFromConsole<string>("Введите имя третьего пациента: "));

            Console.WriteLine($"Список пациентов: {string.Join(", ", patients)}.");

            while (patients.Count > 0)
            {
                Console.WriteLine($"Осмотр пациента {patients.Dequeue()}.");

                if (patients.Count > 0)
                {
                    Console.WriteLine($"Следующий в очереди {patients.Peek()}.");
                }
                else
                {
                    Console.WriteLine($"Очередь закончилась.");
                }
            }
            Console.WriteLine("Доктор закончил осматривать пациентов.");

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}