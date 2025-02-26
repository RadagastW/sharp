namespace Sharp.ConsoleApp.Commands.Warriors
{
    public class Barbarian : Warrior
    {
        public Barbarian(int health, int armor, int damage, int attackSpeed)
            : base(health, armor, damage * attackSpeed)
        {
            Name = "Варвар";
        }

        public void Shout()
        {
            Armor -= 2;
            Health += 10;
        }
    }
}