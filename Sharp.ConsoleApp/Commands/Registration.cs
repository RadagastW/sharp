using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для регистрации пассажиров на рейс.
    /// </summary>
    public class Registration : ICommand
    {
        private readonly int[] _sectors = { 6, 28, 15, 15, 17 };

        /// <summary>
        /// Выполнить команду для регистрации пассажиров на рейс.
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                DisplaySectors();
                DisplayMenu();

                switch (ConsoleUtilites.ReadFromConsole<int>("Введите номер команды: "))
                {
                    case 1:
                        BookSeats();
                        break;
                    case 2:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Отображает текущее состояние секторов и количество свободных мест.
        /// </summary>
        private void DisplaySectors()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            for (int i = 0; i < _sectors.Length; i++)
            {
                Console.WriteLine($"В секторе {i + 1} свободно {_sectors[i]} мест.");
            }
            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Отображает главное меню для выбора действия.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("Регистрации пассажиров на рейс.");
            Console.WriteLine("\n\n1 - забронировать места\n\n2 - выход из программы\n\n");
        }

        /// <summary>
        /// Обрабатывает бронирование мест в указанном секторе.
        /// </summary>
        private void BookSeats()
        {
            int userSector = ConsoleUtilites.ReadFromConsole<int>("Сектор: ");

            if (userSector < 1 || userSector > _sectors.Length)
            {
                Console.WriteLine("Неверный сектор.");
                return;
            }

            int userPlaceAmount = ConsoleUtilites.ReadFromConsole<int>("Количество мест: ");

            if (userPlaceAmount < 1 || userPlaceAmount > _sectors[userSector - 1])
            {
                Console.WriteLine("Неверное количество мест.");
                return;
            }

            _sectors[userSector - 1] -= userPlaceAmount;
            Console.WriteLine("Места забронированы.");
        }
    }
}