using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для Carts.
    /// </summary>
    public class Template : ICommand
    {
        /// <summary>
        /// Выполнить команду для Carts.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Carts\"");

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

    public class Cart
    {
        private List<Product> _products = new List<Product>();

        public Cart()
        {
            _products.Add(new Product("1"));
            _products.Add(new Product("2"));
            _products.Add(new Product("3"));
            _products.Add(new Product("4"));
            _products.Add(new Product("5"));
        }

        public void ShowProducts()
        {
            foreach (var product in _products)
            {
                Console.WriteLine(product.Name);
            }
        }

        public int GetProductsCount()
        {
            return _products.Count;
        }

        public Product GetProductByIndex(int index)
        {
            return _products.ElementAt(index);
        }
    }

    public class Product
    {
        public string Name { get; private set; }

        public Product(string name)
        {
            Name = name;
        }
    }
}