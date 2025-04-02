using System;

namespace Sharp.ConsoleApp.Commands.Generic
{
    public partial class GenericArrayExample
    {
        public class GenericArray<T>
        {
            public T[] Elements { get; private set; }

            public GenericArray(T[] array)
            {
                Elements = array;
            }

            public void ShowTypeArray()
            {
                Console.WriteLine($"Тип: {Elements}.");
            }

            public void ShowArray()
            {
                Console.WriteLine($"Массив: {string.Join(", ", Elements)}.");
            }

            public void ShowElementAt(int index)
            {
                if (index < 0 || index >= Elements.Length)
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива.");

                Console.WriteLine($"Элемент массива: {Elements[index]}.");
            }

            public int GetLength()
            {
                return Elements.Length;
            }

            public void AddElement(T element)
            {
                T[] newArray = new T[Elements.Length + 1];

                Array.Copy(Elements, newArray, Elements.Length);
                newArray[newArray.Length - 1] = element;

                Elements = newArray;
            }

            public void RemoveAt(int index)
            {
                if (index < 0 || index >= Elements.Length)
                    throw new IndexOutOfRangeException("Индекс находится вне границ массива.");

                T[] newArray = new T[Elements.Length - 1];

                for (int i = 0; i < index; i++)
                    newArray[i] = Elements[i];

                for (int i = index + 1; i < Elements.Length; i++)
                    newArray[i - 1] = Elements[i];

                Elements = newArray;
            }
        }
    }
}