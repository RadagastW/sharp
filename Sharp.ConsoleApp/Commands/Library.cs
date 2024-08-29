using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для системы управления библиотекой.
    /// </summary>
    public class Library : ICommand
    {
        private readonly string[,] _books =
        {
            { "book1", "book2", "book3" },
            { "book4", "book5", "book6" },
            { "book7", "book8", "book9" },
        };

        /// <summary>
        /// Выполнить команду для системы управления библиотекой.
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                DisplayBooks();
                DisplayMenu();

                switch (ConsoleUtilites.ReadFromConsole<int>("Введите номер команды: "))
                {
                    case 1:
                        FindBook();
                        break;
                    case 2:
                        FindIndex();
                        break;
                    case 3:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Отображает текущее состояние библиотеки.
        /// </summary>
        private void DisplayBooks()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 20);

            Console.WriteLine("Список книг:");

            for (int line = 0; line < _books.GetLength(0); line++)
            {
                Console.Write(" | ");
                for (int column = 0; column < _books.GetLength(1); column++)
                {
                    Console.Write(_books[line, column] + " | ");
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, 0);
        }

        /// <summary>
        /// Отображает главное меню для выбора действия.
        /// </summary>
        private void DisplayMenu()
        {
            Console.WriteLine("Библиотека.");
            Console.WriteLine("\n\n1 - найти книгу по позиции\n\n2 - найти позицию книги по имени\n\n3 - выход из программы\n\n");
        }

        /// <summary>
        /// Находит книгу по ее позиции.
        /// </summary>
        private void FindBook()
        {
            int line = ConsoleUtilites.ReadFromConsole<int>("Введите номер полки: ") - 1;
            int column = ConsoleUtilites.ReadFromConsole<int>("Введите позицию книги на полке: ") - 1;

            if (line >= 0 && line < _books.GetLength(0)
                && column >= 0 && column < _books.GetLength(1))
            {
                Console.WriteLine($"Найдена книга {_books[line, column]}.");
            }
            else
            {
                Console.WriteLine($"Такой книги не существует.");
            }
        }

        /// <summary>
        /// Находит позицию книги по ее названию.
        /// </summary>
        private void FindIndex()
        {
            string author = ConsoleUtilites.ReadFromConsole<string>("Введите имя книги: ");

            for (int line = 0; line < _books.GetLength(0); line++)
            {
                for (int column = 0; column < _books.GetLength(1); column++)
                {
                    if (_books[line, column].ToUpper().Trim() == author.ToUpper().Trim())
                    {
                        Console.WriteLine($"Номер полки - {line + 1}, позиция - {column + 1}.");
                        return;
                    }
                }
            }

            Console.WriteLine($"Такой книги не существует.");
        }
    }
}
