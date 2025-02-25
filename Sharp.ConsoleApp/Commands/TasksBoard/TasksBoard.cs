using Sharp.ConsoleApp.Interfaces;
using System;

namespace Sharp.ConsoleApp.Commands.TasksBoard
{
    /// <summary>
    /// Команда для запуска TasksBoard.
    /// </summary>
    public class TasksBoard : ICommand
    {
        /// <summary>
        /// Выполнить команду для запуска TasksBoard.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("\"Расписание задач\"\n");

            Performer worker1 = new Performer("Worker1");
            Performer worker2 = new Performer("Worker2");
            Performer worker3 = new Performer("Worker3");

            Task[] tasks =
            {
                new Task(worker1, "Description..."),
                new Task(worker2, "Description..."),
                new Task(worker3, "Description..."),
            };

            Board schedule = new Board(tasks);

            schedule.ShowAllTasks();

            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}