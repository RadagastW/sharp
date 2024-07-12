namespace Sharp.ConsoleApp.Interfaces
{
    /// <summary>
    /// Интерфейс для выполнения команды.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить команду.
        /// </summary>
        void Execute();
    }
}