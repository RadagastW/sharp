namespace Sharp.ConsoleApp.Commands.TasksBoard
{
    public class Board
    {
        public Task[] Tasks;

        public Board(Task[] tasks)
        {
            Tasks = tasks;
        }

        public void ShowAllTasks()
        {
            foreach (var task in Tasks)
            {
                task.ShowInfo();
            }
        }
    }
}