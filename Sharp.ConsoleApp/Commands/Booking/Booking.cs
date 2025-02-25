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
        private readonly Table[] _tables = new[]
        {
            new Table(1, 4),
            new Table(2, 8),
            new Table(3, 10)
        };

        /// <summary>
        /// Выполнить команду для бронирования в кафе.
        /// </summary>
        public void Execute()
        {
            try
            {
                bool isOpen = true;

                while (isOpen)
                {
                    DisplayTables();
                    Reservation();
                    isOpen = AskToContinue();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private void DisplayTables()
        {
            Console.Clear();
            Console.WriteLine("Бронирование.\n");

            foreach (var table in _tables)
            {
                table.ShowInfo();
            }

            Console.WriteLine();
        }

        private bool Reservation()
        {
            int wishTable = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите номер стола: ") - 1;
            int desiredPlaces = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите количество мест для бронирования: ");

            bool isReservationCompleted = wishTable < _tables.Length && wishTable >= 0
                ? _tables[wishTable].Reserve(desiredPlaces)
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

            return isReservationCompleted;
        }

        private bool AskToContinue()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            ConsoleKeyInfo charKey = Console.ReadKey(true);

            if (charKey.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return false;
            }

            return true;
        }
    }
}