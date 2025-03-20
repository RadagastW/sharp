using System;

namespace Sharp.ClassLibrary
{
    public class Person
    {
        private string _name;

        public Person(string name)
        {
            _name = name;
        }

        public void Print() => Console.WriteLine($"Name: {_name}");
    }
}