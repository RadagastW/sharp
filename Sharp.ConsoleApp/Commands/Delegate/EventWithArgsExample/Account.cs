namespace Sharp.ConsoleApp.Commands.Delegate.EventWithArgsExample
{
    public class Account
    {
        public delegate void AccountHandler(Account sender, AccountEventArgs e);
        public event AccountHandler Notify;

        public int Sum;

        public Account(int sum)
        {
            Sum = sum;
        }

        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
        }

        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;

                Notify?.Invoke(this, new AccountEventArgs($"Со счета списано {sum} у.е.", sum));
            }
            else
            {
                Notify?.Invoke(this, new AccountEventArgs($"Недостаточно средств. Баланс: {Sum} у.е.", sum));
            }
        }
    }
}