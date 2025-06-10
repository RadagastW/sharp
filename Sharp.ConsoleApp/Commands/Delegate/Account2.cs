namespace Sharp.ConsoleApp.Commands.Delegate
{
    public class Account2
    {
        public delegate void AccountHandler(string message);

        // 1.Определение события
        public event AccountHandler Notify;

        private int _sum;

        public Account2(int sum)
        {
            _sum = sum;
        }

        public void Put(int sum)
        {
            _sum += sum;

            // 2.Вызов события 
            Notify?.Invoke($"На счет поступило: {sum}");
        }

        public void Take(int sum)
        {
            if (_sum >= sum)
            {
                _sum -= sum;

                // 2.Вызов события 
                Notify?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                // 2.Вызов события 
                Notify?.Invoke($"Недостаточно средств. Баланс: {_sum} у.е.");
            }
        }
    }
}