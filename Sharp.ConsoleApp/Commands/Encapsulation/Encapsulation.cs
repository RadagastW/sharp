using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands.Encapsulation
{
    /// <summary>
    /// Команда для Encapsulation.
    /// </summary>
    public class Encapsulation : ICommand
    {
        /// <summary>
        /// Выполнить команду для Encapsulation.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Encapsulation\"");

            Cart cart = new Cart();
            cart.ShowProducts();

            List<Product> products = new List<Product>();

            for (int i = 0; i < cart.GetProductsCount(); i++)
            {
                products.Add(cart.GetProductByIndex(i));
            }

            products.RemoveAt(0);

            Console.WriteLine();
            cart.ShowProducts();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}