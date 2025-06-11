using System;

namespace Sharp.ConsoleApp.Commands.Delegate.DelegateExample
{
    public static class MathHelper
    {
        public static int Add(int x, int y) => x + y;
        public static int Subtract(int x, int y) => x - y;
        public static int Multiply(int x, int y) => x * y;

        public static void PrintAddition(int x, int y) => Console.WriteLine($"Add: {Add(x, y)}.");
        public static void PrintSubtraction(int x, int y) => Console.WriteLine($"Subtract: {Subtract(x, y)}.");
        public static void PrintMultiplication(int x, int y) => Console.WriteLine($"Multiply: {Multiply(x, y)}.");

        internal static void DoOperation(int a, int b, Operation operation)
        {
            Console.WriteLine(operation(a, b));
        }
    }
}