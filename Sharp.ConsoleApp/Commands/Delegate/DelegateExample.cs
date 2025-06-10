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
            DemonstrateBasicDelegates();
            DemonstrateMulticastDelegates();
            DemonstrateDelegatesAsParameters();
            DemonstrateReturningDelegates();
            DemonstratePracticalUse();
            DemonstrateAnonymousMethods();

            WaitForUserInput();
        }

        private void DemonstrateBasicDelegates()
        {
            Console.WriteLine("\"Примеры работы с делегатами\"\n");

            Operation operation = MathHelper.Add;
            Console.WriteLine(operation(1, 2));

            operation = new Operation(MathHelper.Subtract); // альтернативный способ присвоения
            Console.WriteLine(operation?.Invoke(5, 6)); // альтернативный вызов делегата
        }

        private void DemonstrateMulticastDelegates()
        {
            Console.WriteLine("\nОбъединение делегатов\n");

            OperationPrinter operationPrinter = MathHelper.PrintAddition;
            operationPrinter += MathHelper.PrintSubtraction;
            operationPrinter += MathHelper.PrintMultiplication;
            operationPrinter?.Invoke(5, 6);
        }

        private void DemonstrateDelegatesAsParameters()
        {
            Console.WriteLine("\nДелегаты как параметры методов\n");

            MathHelper.DoOperation(7, 8, MathHelper.Add);
            MathHelper.DoOperation(7, 8, MathHelper.Subtract);
            MathHelper.DoOperation(7, 8, MathHelper.Multiply);
        }

        private void DemonstrateReturningDelegates()
        {
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

            Operation operation = SelectOperation(OperationType.Add);
            Console.WriteLine(operation(9, 10));

            operation = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation(9, 10));

            operation = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation(9, 10));
        }

        private void DemonstratePracticalUse()
        {
            Console.WriteLine("\nПрименение делегатов\n");

            Account account = new Account(200);

            account.RegisterHandler(PrintSimpleMessage);
            account.RegisterHandler(PrintColorMessage);

            account.Take(100);
            account.Take(150);

            account.UnregisterHandler(PrintColorMessage);
            account.Take(50);
        }

        #region DemonstratePracticalUse

        private void PrintSimpleMessage(string message)
        {
            Console.WriteLine(message);
        }

        private void PrintColorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        #endregion

        private void DemonstrateAnonymousMethods()
        {
            Console.WriteLine("\nПрименение анонимных методов\n");

            MessageHandler handler = delegate (string message)
            {
                Console.WriteLine(message);
            };
            handler("Здесь анонимный метод используется для инициализации экземпляра делегата.");

            ShowMessage("Здесь анонимный метод передается в качестве аргумента для параметра, который представляет делегат.", delegate (string message)
            {
                Console.WriteLine(message);
            });
        }

        #region DemonstrateAnonymousMethods

        private static void ShowMessage(string message, MessageHandler handler)
        {
            handler(message);
        }

        #endregion

        private void WaitForUserInput()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }

    public delegate int Operation(int x, int y);
    public delegate void OperationPrinter(int x, int y);
    public delegate void MessageHandler(string message);
}