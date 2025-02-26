using System;

namespace Sharp.ConsoleApp.Commands.Render
{
    public class Renderer
    {
        public void Draw(int x, int y, char character = '@')
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(character);
            Console.SetCursorPosition(0, 1);
            Console.ReadKey(true);
        }
    }
}