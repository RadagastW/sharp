using System;

namespace Sharp.ConsoleApp.Commands.Warriors
{
    public class Warrior
    {
        public string Name;

        public int Health;
        public int Armor;
        public int Damage;

        public Warrior(int health, int armor, int damage)
        {
            Name = "Воин";

            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage - Armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}.");
            Console.WriteLine($"Здоровье: {Health}\nБроня: {Armor}\nУрон: {Damage}\n");
        }
    }
}