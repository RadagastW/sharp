using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands.LINQ
{
    /// <summary>
    /// Команда для работы с LINQ.
    /// </summary>
    public class LinqExamples : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с LINQ.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"LINQ\"");

            List<Player> players = new List<Player>
            {
                new Player("Login1", 5),
                new Player("Login2", 5),
                new Player("Login3", 3),
                new Player("Login4", 2),
                new Player("Login5", 1)
            };

            PlayerManager playerManager = new PlayerManager(players);

            playerManager.ShowFiltredPlayerNames();
            playerManager.ShowOrderedPlayers();
            playerManager.ShowMaxLevel();
            playerManager.ShowNewPlayers();
            playerManager.ShowUnionTeam();
            playerManager.ShowFilteredPlayersWithSkipAndTake();

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}