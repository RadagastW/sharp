using System;

namespace Sharp.ConsoleApp.Commands.Fighters
{
    public class Fighter
    {
        public string Name { get; }
        public int Heath { get; private set; }
        public int Damage { get; }
        public int Armor { get; }

        public Fighter(string name, int health, int damage, int armor)
        {
            Name = name;
            Heath = health;
            Damage = damage;
            Armor = armor;
        }

        public void ShowStats()
        {
            Console.WriteLine($"Боец - {Name}, здоровье: {Heath}, урон: {Damage}, броня: {Armor}.");
        }

        public void ShowCurrentHealth()
        {
            Console.WriteLine($"Боец - {Name}, здоровье: {Heath}.");
        }

        public void TakeDamage(int damage)
        {
            Heath -= damage - Armor;
        }
    }
}