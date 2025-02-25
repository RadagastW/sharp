using System;

namespace Sharp.ConsoleApp.Commands.TasksBoard
{
    public class Task
    {
        public Performer Worker;
        public string Description;

        public Task(Performer worker, string description)
        {
            Worker = worker;
            Description = description;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Ответственный: {Worker.Name}\nОписание задачи: {Description}\n");
        }
    }
}