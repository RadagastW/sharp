using System;

namespace Sharp.ConsoleApp.Commands
{
    public class Client
    {
        public int DesiredMinutes { get; private set; }

        private int _money;
        private int _moneyToPay;

        public Client(int money, Random random)
        {
            _money = money;
            DesiredMinutes = random.Next(1, 31);
        }

        public bool CheckSolvency(Computer computer)
        {
            _moneyToPay = DesiredMinutes * computer.PricePerMinutes;

            if (_money > _moneyToPay)
            {
                return true;
            }
            else
            {
                _moneyToPay = 0;
                return false;
            }
        }

        public int Pay()
        {
            _money -= _moneyToPay;
            return _moneyToPay;
        }
    }
}