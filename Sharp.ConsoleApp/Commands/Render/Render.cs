using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Render
{
    /// <summary>
    /// Команда для Render.
    /// </summary>
    public class Render : ICommand
    {
        /// <summary>
        /// Выполнить команду для Render.
        /// </summary>
        public void Execute()
        {
            Renderer renderer = new Renderer();
            Player player = new Player(50, 0);

            renderer.Draw(player.X, player.Y);

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}