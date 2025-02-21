using Sharp.ConsoleApp.Commands.Packman;
using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands.Booking
{
    /// <summary>
    /// Команда для бронирования в кафе.
    /// </summary>
    public class Booking : ICommand
    {
        /// <summary>
        /// Выполнить команду для бронирования в кафе.
        /// </summary>
        public void Execute()
        {
            bool isOpen = true;

            Table[] tables = { new Table(1, 4), new Table(2, 8), new Table(3, 10) };

            while (isOpen)
            {
                Console.Clear();
                Console.WriteLine("Бронирование.\n");

                foreach (Table table in tables)
                {
                    table.ShowInfo();
                }

                Console.WriteLine("");

                int wishTable = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите номер стола: ") - 1;
                int desiredPlaces = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите количество мест для бронирования: ");

                bool isReservationCompleted = wishTable < tables.Length && wishTable >= 0
                    ? tables[wishTable].Reserve(desiredPlaces)
                    : false;

                Console.WriteLine();

                if (isReservationCompleted)
                {
                    Console.WriteLine("Бронирование выполнено.");
                }
                else
                {
                    Console.WriteLine("Невозможно забронировать места.");
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                ConsoleKeyInfo charKey = Console.ReadKey();

                if (charKey.Key == ConsoleKey.Escape)
                {
                    isOpen = false;
                    Console.Clear();
                }
            }
        }
    }
}