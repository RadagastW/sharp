namespace Sharp.ConsoleApp.Commands.Delegate
{
    public class Account
    {
        public delegate void AccountHandler(string message);
        private AccountHandler _taken;
        private int _sum;

        public Account(int sum)
        {
            _sum = sum;
        }

        // Регистрация делегата
        public void RegisterHandler(AccountHandler del)
        {
            _taken += del;
        }

        // Отмена регистрации делегата
        public void UnregisterHandler(AccountHandler del)
        {
            _taken -= del;
        }

        public void Add(int sum)
        {
            _sum += sum;
        }

        public void Take(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;

                _taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                _taken?.Invoke($"Недостаточно средств. Баланс: {_sum} у.е.");
            }
        }
    }
}