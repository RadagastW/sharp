using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharp.ConsoleApp.Commands.LINQ
{
    public class PlayerManager
    {
        readonly List<Player> _players;

        public PlayerManager(List<Player> players)
        {
            _players = players;
        }

        public void ShowFiltredPlayerNames()
        {
            Console.WriteLine("\nОтфильтрованный список имен игроков.");

            /*
            IEnumerable<Player> filtredPlayers = from Player player
                                                 in players1
                                                 where player.Level > 1
                                                 select player.Name;
            */

            IEnumerable<string> filtredPlayerNames = _players
                .Where(player => player.Level > 1)
                .Select(player => player.Name);

            foreach (string name in filtredPlayerNames)
            {
                Console.WriteLine($"Имя: {name}.");
            }
        }

        public void ShowOrderedPlayers()
        {
            Console.WriteLine("\nОтсортированный список игроков.");

            IEnumerable<Player> orderedPlayers = _players
                .Where(player => player.Level > 1)
                .OrderBy(player => player.Level)
                .ThenByDescending(player => player.Name);

            foreach (Player player in orderedPlayers)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }
        }

        public void ShowMaxLevel()
        {
            int maxLevel = _players.Max(player => player.Level);
            Console.WriteLine($"\nМаксимальный уровень: {maxLevel}.");
        }

        public void ShowNewPlayers()
        {
            Console.WriteLine("\nНовые игроки.");

            Random random = new Random();

            /*
            var newPlayers = from Player player
                             in players
                             select new
                             {
                                 Name = player.Name,
                                 DateOfCreate = DateTime.Now,
                                 RandomNumber = random.Next(1, 11)
                             };
            */

            var newPlayers = _players
                .Select(player => new
                {
                    Name = player.Name,
                    DateOfCreate = DateTime.Now,
                    RandomNumber = random.Next(1, 11)
                });

            foreach (var player in newPlayers)
            {
                Console.WriteLine($"Имя: {player.Name}, дата создания: {player.DateOfCreate}, случайное число: {player.RandomNumber}.");
            }
        }

        public void ShowUnionTeam()
        {
            Console.WriteLine("\nВсе игроки.");

            List<Player> newPlayers = new List<Player>
            {
                new Player("Login6", 1),
                new Player("Login7", 7),
                new Player("Login8", 2)
            };

            IEnumerable<Player> unitedTeam = _players.Union(newPlayers);

            foreach (Player player in unitedTeam)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }
        }

        public void ShowFilteredPlayersWithSkipAndTake()
        {
            Console.WriteLine("\nSkip и Take.");

            IEnumerable<Player> filtredPlayers1 = _players.Skip(3);

            foreach (Player player in filtredPlayers1)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }

            Console.WriteLine(new string('-', 23));

            IEnumerable<Player> filtredPlayers2 = _players.Take(1);

            foreach (Player player in filtredPlayers2)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }

            Console.WriteLine(new string('-', 23));

            IEnumerable<Player> filtredPlayers3 = _players.SkipWhile(player => player.Name.ToUpper().EndsWith("3"));

            foreach (Player player in filtredPlayers3)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }

            Console.WriteLine(new string('-', 23));

            IEnumerable<Player> filtredPlayers4 = _players.TakeWhile(player => player.Level >= 5);

            foreach (Player player in filtredPlayers4)
            {
                Console.WriteLine($"Имя: {player.Name}, уровень {player.Level}.");
            }
        }
    }
}