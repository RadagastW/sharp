namespace Sharp.ConsoleApp.Commands.Delegate
{
    public class AccountEventArgs
    {
        public string Message { get; }
        public int Sum { get; }

        public AccountEventArgs(string message, int sum)
        {
            Message = message;
            Sum = sum;
        }
    }
}