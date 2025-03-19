using System;

namespace Sharp.ConsoleApp.Commands.Enum
{
    public class Game
    {
        private string _title;
        private Genre _genre;

        public Game(string title, Genre genre)
        {
            _title = title;
            _genre = genre;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Title: {_title}, genre: {_genre}.");
        }
    }
}