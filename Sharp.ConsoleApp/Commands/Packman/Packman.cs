using Sharp.ConsoleApp.Interfaces;
using System;
using System.IO;

namespace Sharp.ConsoleApp.Commands.Packman
{
    /// <summary>
    /// Команда для запуска игры "Packman".
    /// </summary>
    public class Packman : ICommand
    {
        private const char WALL = '#';
        private const char EMPTY = ' ';
        private const char TREASURE = 'x';
        private const char PLAYER = '@';
        private const string MAP_PATH = "Commands/Packman/Resources/map.txt";

        private char[,] _map;
        private int _playerX;
        private int _playerY;
        private int _score;

        private ConsoleColor _defaultColor;

        /// <summary>
        /// Выполнить команду для запуска игры "Packman".
        /// </summary>
        public void Execute()
        {
            try
            {
                InitializeGame();
                RunGameLoop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            finally
            {
                Cleanup();
            }
        }

        private void InitializeGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            _defaultColor = Console.ForegroundColor;

            _map = ReadMap(MAP_PATH);
            (_playerX, _playerY) = GetInitialPlayerPosition(_map);

            _score = 0;
        }

        private void RunGameLoop()
        {
            while (true)
            {
                RenderGame();

                if (!ProcessInput())
                    break;
            }
        }

        private void RenderGame()
        {
            DrawMap();
            DrawPlayer();
            DisplayStatus(_map.GetLength(0));
        }

        private void DisplayStatus(int mapLength)
        {
            Console.ForegroundColor = _defaultColor;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("\"Packman\"");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(mapLength + 1, 2);
            Console.Write($"Score: {_score}");

            Console.SetCursorPosition(0, 0);
        }

        private void DrawMap()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 2);
            for (int y = 0; y < _map.GetLength(1); y++)
            {
                for (int x = 0; x < _map.GetLength(0); x++)
                {
                    Console.Write(_map[x, y]);
                }
                Console.WriteLine();
            }
        }

        private void DrawPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(_playerX, _playerY);
            Console.Write(PLAYER);
        }

        private bool ProcessInput()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();

            int nextX = _playerX;
            int nextY = _playerY;

            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow: nextY--; break;
                case ConsoleKey.W: nextY--; break;
                case ConsoleKey.DownArrow: nextY++; break;
                case ConsoleKey.S: nextY++; break;
                case ConsoleKey.LeftArrow: nextX--; break;
                case ConsoleKey.A: nextX--; break;
                case ConsoleKey.RightArrow: nextX++; break;
                case ConsoleKey.D: nextX++; break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    return false;
            }

            if (IsMoveValid(_map, nextX, nextY))
            {
                _playerX = nextX;
                _playerY = nextY;

                CollectTreasure();
            }

            Console.Clear();

            return true;
        }

        private void CollectTreasure()
        {
            if (_map[_playerX, _playerY - 2] == TREASURE)
            {
                _map[_playerX, _playerY - 2] = EMPTY;
                _score += 100;
            }
            else
            {
                _score++;
            }
        }

        private void Cleanup()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.ForegroundColor = _defaultColor;
        }

        private static char[,] ReadMap(string filePath)
        {
            string[] file = File.ReadAllLines(filePath);

            char[,] map = new char[GetMaxLengthOfLines(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;
        }

        private static int GetMaxLengthOfLines(string[] lines)
        {
            int maxLength = lines[0]?.Length ?? 0;
            foreach (string line in lines)
            {
                maxLength = Math.Max(maxLength, line.Length);
            }

            return maxLength;
        }

        private static (int x, int y) GetInitialPlayerPosition(char[,] map)
        {
            return (map.GetLength(0) / 2, map.GetLength(1) / 2 + 2);
        }

        private static bool IsMoveValid(char[,] map, int x, int y)
        {
            return map[x, y - 2] != WALL;
        }
    }
}