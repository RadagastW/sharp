using Sharp.ConsoleApp.Utilities;
using System;
using System.Collections.Generic;

namespace Sharp.ConsoleApp.Commands
{
    public class ComputerClub
    {
        private int _money = 0;
        private List<Computer> _computers = new List<Computer>();
        private Queue<Client> _clients = new Queue<Client>();

        public ComputerClub(int computersCount)
        {
            Random random = new Random();

            for (int i = 0; i < computersCount; i++)
            {
                _computers.Add(new Computer(random.Next(5, 16)));
            }

            CreateNewClients(25, random);
        }

        public void CreateNewClients(int count, Random random)
        {
            for (int i = 0; i < count; i++)
            {
                _clients.Enqueue(new Client(random.Next(100, 251), random));
            }
        }

        public void Work()
        {
            while (_clients.Count > 0)
            {
                Client newClient = _clients.Dequeue();
                Console.WriteLine($"Баланс: {_money}. Ожидание нового клиента.");
                Console.WriteLine($"Новый клиент. Требуется {newClient.DesiredMinutes} мин.");
                ShowAllComputersState();

                int computerIndex = ReadComputerIndex();

                if (_computers[computerIndex].IsTaken)
                {
                    Console.WriteLine("Компьютер занят.");
                }
                else
                {
                    if (newClient.CheckSolvency(_computers[computerIndex]))
                    {
                        Console.WriteLine($"Был оплачен компьютер {computerIndex + 1}.");
                        _money += newClient.Pay();
                        _computers[computerIndex].BecomeTaken(newClient);
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств.");
                    }
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey(true);
                Console.Clear();
                SpendOneMinutes();
            }
        }

        private void ShowAllComputersState()
        {
            Console.WriteLine("\nСписок всех компьютеров:");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.Write(i + 1 + " - ");
                _computers[i].ShowState();
            }
        }

        private int ReadComputerIndex()
        {
            while (true)
            {
                int userInput = (int)ConsoleUtilites.ReadFromConsole<uint>("\nИспользуется компьютер под номером: ") - 1;

                if (userInput < 0 || userInput >= _computers.Count)
                {
                    CreateNewClients(1, new Random());
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите правильное число.");
                }
                else
                {
                    return userInput;
                }
            }
        }

        private void SpendOneMinutes()
        {
            foreach (Computer computer in _computers)
            {
                computer.SpendOneMinute();
            }
        }
    }
}