using Sharp.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    /// <summary>
    /// Команда для работы со словарем Dictionary.
    /// </summary>
    public class Dictionaries : ICommand
    {
        /// <summary>
        /// Выполнить команду для работы со словарем Dictionary.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Словарь Dictionary\"");

            Dictionary<string, string> countriesCapitalsAdditional = new Dictionary<string, string>()
            {
                { "Ivory Coast", "Abidjan" }
            };

            Dictionary<string, string> countriesCapitals = new Dictionary<string, string>(countriesCapitalsAdditional)
            {
                ["Ghana"] = "Accra",
                ["Ethiopia"] = "Addis Ababa",
                ["Jordan"] = "Amman",
                ["Samoa"] = "Apia",
                ["Greece"] = "Athens"
            };

            countriesCapitals.Add("Lebanon", "Beirut");
            countriesCapitals.Remove("Jordan");

            if (countriesCapitals.ContainsKey("Ivory Coast"))
            {
                Console.WriteLine($"Столица Ivory Coast: {countriesCapitals["Ivory Coast"]}.");
            }

            foreach (KeyValuePair<string, string> item in countriesCapitals)
            {
                if (item.Key != "Ivory Coast")
                {
                    Console.WriteLine($"Столица {item.Key}: {item.Value}.");
                }
            }

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}