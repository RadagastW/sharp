namespace Sharp.ConsoleApp.Commands.Warriors
{
    public class Knight : Warrior
    {
        public Knight(int health, int damage)
            : base(health, 5, damage)
        {
            Name = "Рыцарь";
        }

        public void Pray()
        {
            Armor += 2;
        }
    }
}