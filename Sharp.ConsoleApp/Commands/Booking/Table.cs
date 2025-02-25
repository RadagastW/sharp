using System;

namespace Sharp.ConsoleApp.Commands.Booking
{
    public class Table
    {
        public int Number;
        public int MaxPlaces;
        public int FreePlaces;

        public Table(int number, int maxPlaces)
        {
            Number = number;
            MaxPlaces = maxPlaces;
            FreePlaces = maxPlaces;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Стол: {Number}. Свободных мест: {FreePlaces} из {MaxPlaces}.");
        }

        public bool Reserve(int plases)
        {
            if (FreePlaces >= plases)
            {
                FreePlaces -= plases;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}