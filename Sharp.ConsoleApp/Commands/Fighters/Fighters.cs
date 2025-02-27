using Sharp.ConsoleApp.Interfaces;
using Sharp.ConsoleApp.Utilities;
using System;

namespace Sharp.ConsoleApp.Commands.Fighters
{
    /// <summary>
    /// Команда для игры "Гладиаторы" v2.0.
    /// </summary>
    public class Fighters : ICommand
    {
        /// <summary>
        /// Выполняет команду для запуска игры "Fighters", в которой два бойца сражаются друг с другом.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Fighters\"");

            Fighter[] fighters =
            {
                new Fighter("1", 100, 10, 0),
                new Fighter("2", 200, 5, 0),
                new Fighter("3", 20, 30, 0),
                new Fighter("4", 50, 5, 50),
                new Fighter("5", 80, 8, 10)
            };

            for (int i = 0; i < fighters.Length; i++)
            {
                Console.Write($"{i + 1}: ");
                fighters[i].ShowStats();
            }

            int index;
            Console.WriteLine("\n** " + new string('-', 25) + " **\n");

            index = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите индекс первого бойца: ") - 1;
            Fighter firstFighter = index >= 0 || index < fighters.Length
                ? fighters[index]
                : fighters[0];

            index = (int)ConsoleUtilites.ReadFromConsole<uint>("Введите индекс второго бойца: ") - 1;
            Fighter secondFighter = index >= 0 || index < fighters.Length
                ? fighters[index]
                : fighters[0];

            Console.WriteLine("\n** " + new string('-', 25) + " **\n");

            int j = 0;
            while (firstFighter.Heath > 0 && secondFighter.Heath > 0)
            {
                firstFighter.TakeDamage(secondFighter.Damage);
                secondFighter.TakeDamage(firstFighter.Damage);
                firstFighter.ShowCurrentHealth();
                secondFighter.ShowCurrentHealth();

                if (j++ == 100)
                    break;
            }

            Console.WriteLine("\n** " + new string('-', 25) + " **\n");

            string winner = string.Empty;

            if ((firstFighter.Heath > 0 && secondFighter.Heath > 0)
                || (firstFighter.Heath < 0 && secondFighter.Heath < 0)
                || firstFighter.Heath == secondFighter.Heath)
            {
                winner = "не определен";
            }
            else
            {
                winner = firstFighter.Heath > secondFighter.Heath
                        ? firstFighter.Name
                        : secondFighter.Name;
            }

            Console.WriteLine($"Победитель: {winner}.");

            Console.WriteLine("\n** " + new string('-', 25) + " **\n");

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}