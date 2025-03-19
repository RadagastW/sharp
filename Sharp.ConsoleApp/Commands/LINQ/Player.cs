namespace Sharp.ConsoleApp.Commands.LINQ
{
    public class Player
    {
        public string Name { get; private set; }
        public int Level { get; private set; }

        public Player(string login, int level)
        {
            Name = login;
            Level = level;
        }
    }
}