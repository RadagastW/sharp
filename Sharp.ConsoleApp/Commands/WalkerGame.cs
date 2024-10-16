using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Класс, реализующий команду для запуска игры "Бродилка".
    /// </summary>
    public class WalkerGame : ICommand
    {
        private const char W = '#';
        private const char S = ' ';
        private const char T = 'x';
        private const char P = '@';

        private char[,] _map =
        {
            { W, W, W, W, W, W, W, W, W, W, W, W, W, W, W },
            { W, S, W, S, S, S, S, W, S, S, T, W, T, T, W },
            { W, S, W, S, S, S, S, W, S, S, T, W, S, S, W },
            { W, S, W, S, S, S, S, S, S, S, T, W, S, S, W },
            { W, S, W, S, S, S, S, W, W, W, W, W, S, S, W },
            { W, S, W, S, S, S, S, S, S, S, S, W, S, S, W },
            { W, S, S, S, S, S, S, S, S, S, S, S, S, S, W },
            { W, S, W, S, S, S, S, S, S, S, S, W, W, W, W },
            { W, S, W, S, S, S, S, S, S, S, S, S, S, S, W },
            { W, S, W, S, S, S, S, S, S, S, S, S, S, S, W },
            { W, S, W, W, W, W, W, S, S, S, S, S, S, S, W },
            { W, S, S, S, S, T, W, S, S, S, S, S, S, S, W },
            { W, W, W, W, W, W, W, W, W, W, W, W, W, W, W }
        };

        private char[] _bag = new char[1];

        private int _userX;
        private int _userY;

        /// <summary>
        /// Запускает игру "Бродилка", инициализируя карту и цикл взаимодействия игрока.
        /// </summary>
        public void Execute()
        {
            InitializeGame();

            while (true)
            {
                RenderGame();

                if (!ProcessInput())
                    break;
            }
        }

        /// <summary>
        /// Инициализирует начальные параметры игры.
        /// </summary>
        private void InitializeGame()
        {
            _userX = _map.GetLength(0) / 2;
            _userY = _map.GetLength(1) / 2;

            Console.CursorVisible = false;
            Console.Clear();
        }

        /// <summary>
        /// Отображает текущее состояние игры, включая карту, игрока и содержимое сумки.
        /// </summary>
        private void RenderGame()
        {
            DrawMap();
            DisplayStatus();
            DrawPlayer(); ;
        }

        /// <summary>
        /// Отображает игровую карту на экране
        /// </summary>
        private void DrawMap()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    Console.Write(_map[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Отображает статус игры (название и содержимое сумки).
        /// </summary>
        private void DisplayStatus()
        {
            Console.SetCursorPosition(0, 18);
            Console.Write("Игра \"Бродилка\"");

            Console.SetCursorPosition(0, 20);
            Console.Write("Сумка:");
            for (int i = 0; i < _bag.Length; i++)
            {
                Console.Write(" " + _bag[i]);
            }
        }

        /// <summary>
        /// Отображает игрока на карте.
        /// </summary>
        private void DrawPlayer()
        {
            Console.SetCursorPosition(_userY, _userX);
            Console.Write(P);
        }

        /// <summary>
        /// Обрабатывает ввод и перемещает игрока.
        /// </summary>
        private bool ProcessInput()
        {
            ConsoleKeyInfo charKey = Console.ReadKey();

            int nextX = _userX;
            int nextY = _userY;

            switch (charKey.Key)
            {
                case ConsoleKey.UpArrow: nextX--; break;
                case ConsoleKey.DownArrow: nextX++; break;
                case ConsoleKey.LeftArrow: nextY--; break;
                case ConsoleKey.RightArrow: nextY++; break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    return false;
            }

            if (IsMoveValid(nextX, nextY))
            {
                _userX = nextX;
                _userY = nextY;

                CollectItem(_userX, _userY);
            }

            Console.Clear();

            return true;
        }

        /// <summary>
        /// Проверяет, можно ли переместиться на указанную позицию.
        /// </summary>
        private bool IsMoveValid(int x, int y)
        {
            return _map[x, y] != W;
        }

        /// <summary>
        /// Собирает предмет, если игрок стоит на сокровище.
        /// </summary>
        private void CollectItem(int x, int y)
        {
            if (_map[_userX, _userY] == T)
            {
                _map[_userX, _userY] = S;

                char[] tempBag = new char[_bag.Length + 1];
                for (int i = 0; i < _bag.Length; i++)
                {
                    tempBag[i] = _bag[i];
                }
                tempBag[tempBag.Length - 1] = T;
                _bag = tempBag;
            }
        }
    }
}