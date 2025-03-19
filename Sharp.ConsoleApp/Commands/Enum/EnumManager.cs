using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands.Enum
{
    /// <summary>
    /// Команда для работы с Enum.
    /// </summary>
    public class EnumManager : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с Enum.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Games\"\n");

            List<Game> games = new List<Game>();
            games.Add(new Game("Fst", Genre.Genre1));
            games.Add(new Game("Snd", Genre.Genre2));
            games.Add(new Game("Srd", Genre.Genre3));

            foreach (Game game in games)
            {
                game.ShowInfo();
            }

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}