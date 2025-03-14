using System;

namespace Sharp.ConsoleApp.Commands
{
    public class Computer
    {
        public int PricePerMinutes { get; private set; }
        public bool IsTaken
        {
            get
            {
                return _minutesRemaining > 0;
            }
        }

        private Client _client;
        private int _minutesRemaining;

        public Computer(int pricePerMinutes)
        {
            PricePerMinutes = pricePerMinutes;
        }

        public void BecomeTaken(Client client)
        {
            _client = client;
            _minutesRemaining = client.DesiredMinutes;
        }

        public void BecomeEmpty()
        {
            _client = null;
        }

        public void SpendOneMinute()
        {
            _minutesRemaining--;
        }

        public void ShowState()
        {
            if (IsTaken)
            {
                Console.WriteLine($"Компьютер занят, осталось минкт: {_minutesRemaining}.");
            }
            else
            {
                Console.WriteLine($"Компьютер свободен, цена за минуту: {PricePerMinutes}.");
            }
        }
    }
}