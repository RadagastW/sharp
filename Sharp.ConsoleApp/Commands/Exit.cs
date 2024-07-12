using Sharp.ConsoleApp.Interfaces;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для выхода из приложения.
    /// </summary>
    internal class Exit : ICommand
    {
        /// <summary>
        /// Выполнить команду выхода.
        /// </summary>
        public void Execute()
        {
            // Пустой метод, так как выход из программы происходит в основном цикле.
        }
    }
}