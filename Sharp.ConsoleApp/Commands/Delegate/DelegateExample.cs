using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.Delegate
{
    /// <summary>
    /// Команда для работы с делегатами.
    /// </summary>
    public class DelegateExample : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы с делегатами.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Пример работы с делегатами\"\n");

            Operation operation = MathHelper.Add;
            Console.WriteLine(operation(1, 2));

            operation = new Operation(MathHelper.Subtract); // альтернативный способ присвоения
            Console.WriteLine(operation?.Invoke(5, 6)); // альтернативный вызов делегата

            Console.WriteLine("\nОбъединение делегатов\n");

            OperationPrinter operationPrinter = MathHelper.PrintAddition;
            operationPrinter += MathHelper.PrintSubtraction;
            operationPrinter += MathHelper.PrintMultiplication;
            operationPrinter?.Invoke(5, 6);

            Console.WriteLine("\nДелегаты как параметры методов\n");

            MathHelper.DoOperation(7, 8, MathHelper.Add);
            MathHelper.DoOperation(7, 8, MathHelper.Subtract);
            MathHelper.DoOperation(7, 8, MathHelper.Multiply);

            Console.WriteLine("\nВозвращение делегатов из метода\n");

            Operation SelectOperation(OperationType opType)
            {
                switch (opType)
                {
                    case OperationType.Add: return MathHelper.Add;
                    case OperationType.Subtract: return MathHelper.Subtract;
                    default: return MathHelper.Multiply;
                }
            }

            operation = SelectOperation(OperationType.Add);
            Console.WriteLine(operation(9, 10));

            operation = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation(9, 10));

            operation = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation(9, 10));

            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }

    delegate int Operation(int x, int y);
    delegate void OperationPrinter(int x, int y);
}