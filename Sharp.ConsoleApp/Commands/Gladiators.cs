using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для игры "Гладиаторы".
    /// </summary>
    public class Gladiators : ICommand
    {
        private readonly Random _rand = new Random();

        /// <summary>
        /// Выполняет команду для запуска игры "Гладиаторы", в которой два гладиатора сражаются друг с другом.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Битва гладиаторов\"");

            var gladiator1 = CreateGladiator("1");
            var gladiator2 = CreateGladiator("2");

            int round = 1;
            while (gladiator1.Health > 0 && gladiator2.Health > 0)
            {
                FightRound(gladiator1, gladiator2, round++);
            }

            AnnounceResult(gladiator1, gladiator2);
        }

        /// <summary>
        /// Создает нового гладиатора с случайными характеристиками.
        /// </summary>
        /// <param name="name">Имя гладиатора.</param>
        /// <returns>Объект <see cref="Gladiator"/> с установленными характеристиками.</returns>
        private Gladiator CreateGladiator(string name)
        {
            var gladiator = new Gladiator
            {
                Health = _rand.Next(10, 101),
                Damage = _rand.Next(1, 21),
                Armor = _rand.Next(0, 51),
                Name = $"Гладиатор {name}"
            };

            Console.WriteLine($"{gladiator.Name} - h:{gladiator.Health} d:{gladiator.Damage} a:{gladiator.Armor}");
            return gladiator;
        }

        /// <summary>
        /// Проводит один раунд боя между двумя гладиаторами.
        /// </summary>
        /// <param name="gladiator1">Первый гладиатор.</param>
        /// <param name="gladiator2">Второй гладиатор.</param>
        /// <param name="round">Текущий номер раунда.</param>
        private void FightRound(Gladiator gladiator1, Gladiator gladiator2, int round)
        {
            Console.WriteLine($"\nРаунд {round}:");

            Attack(gladiator1, gladiator2, round);
            Attack(gladiator2, gladiator1, round);
        }

        /// <summary>
        /// Выполняет атаку одного гладиатора на другого.
        /// </summary>
        /// <param name="attacker">Гладиатор, который атакует.</param>
        /// <param name="defender">Гладиатор, который защищается.</param>
        /// <param name="round">Текущий номер раунда.</param>
        private void Attack(Gladiator attacker, Gladiator defender, int round)
        {
            decimal damageDealt = _rand.Next(0, attacker.Damage + 1);
            decimal actualDamage = damageDealt * (1 - defender.Armor / 100m);
            defender.Health = Math.Max(0, defender.Health - actualDamage);

            Console.WriteLine($"\t{attacker.Name} наносит {damageDealt} урона. {defender.Name} имеет {defender.Health} здоровья.");
        }

        /// <summary>
        /// Объявляет результат боя на основе оставшегося здоровья гладиаторов.
        /// </summary>
        /// <param name="gladiator1">Первый гладиатор.</param>
        /// <param name="gladiator2">Второй гладиатор.</param>
        private void AnnounceResult(Gladiator gladiator1, Gladiator gladiator2)
        {
            string result = gladiator1.Health == gladiator2.Health
                ? "ничья"
                : gladiator1.Health > gladiator2.Health ? $"победил {gladiator1.Name}" : $"победил {gladiator2.Name}";

            Console.WriteLine($"\nРезультат: {result}.");
        }

        /// <summary>
        /// Представляет гладиатора с его характеристиками.
        /// </summary>
        private class Gladiator
        {
            /// <summary>
            /// Здоровье гладиатора.
            /// </summary>
            public decimal Health { get; set; }

            /// <summary>
            /// Наносимый урон гладиатором.
            /// </summary>
            public int Damage { get; set; }

            /// <summary>
            /// Уровень защиты (брони) гладиатора.
            /// </summary>
            public int Armor { get; set; }

            /// <summary>
            /// Имя гладиатора.
            /// </summary>
            public string Name { get; set; }
        }
    }
}