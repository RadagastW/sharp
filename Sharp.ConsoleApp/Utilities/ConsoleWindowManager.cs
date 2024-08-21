using System.Runtime.InteropServices;
using System;

namespace Sharp.ConsoleApp.Utilities
{
    /// <summary>
    /// Класс для управления положением окна консольного приложения.
    /// </summary>
    public class ConsoleWindowManager
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_TOP = IntPtr.Zero;
        const uint SWP_NOSIZE = 0x0001;
        const uint SWP_NOZORDER = 0x0004;

        /// <summary>
        /// Устанавливает позицию окна консольного приложения на экране.
        /// </summary>
        /// <param name="x">Координата X на экране (может быть отрицательной для второго монитора).</param>
        /// <param name="y">Координата Y на экране.</param>
        public static void SetPosition(int x, int y)
        {
            // Получение хэндла окна консоли
            IntPtr hWnd = GetConsoleWindow();

            // Перемещение окна
            SetWindowPos(hWnd, HWND_TOP, x, y, 0, 0, SWP_NOSIZE | SWP_NOZORDER);
        }
    }
}
