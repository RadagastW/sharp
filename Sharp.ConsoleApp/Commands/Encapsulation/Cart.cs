using System;
using System.Collections.Generic;
using System.Linq;

namespace Sharp.ConsoleApp.Commands.Encapsulation
{
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
}