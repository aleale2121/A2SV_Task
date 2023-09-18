namespace TaskManager;
using System;
using System.Threading.Tasks;

public class Program{   
    public static async Task Main(){

        TaskManager taskManager = new TaskManager();
        await taskManager.LoadTasks();
        // Task.Run(async () =>
        // {
        //     await loadTasks(taskManager);
        // }).GetAwaiter().GetResult();

        taskManager.AddTask(new TaskItem("Personal Task 1", "Decription Personal Task 1", Category.Personal, true));
        taskManager.AddTask(new TaskItem("Personal Task 2", "Decription Personal Task 2", Category.Personal, false));
        taskManager.AddTask(new TaskItem("Work Task 1", "Work Decription Task 1", Category.Work, true));
        taskManager.AddTask(new TaskItem("Work Task 2", "Work Decription Task 2", Category.Work, false));
        taskManager.AddTask(new TaskItem("Errands Task 1", "Decription Errands Task 1", Category.Errands, true));
        taskManager.AddTask(new TaskItem("Errands Task 2", "Decription Errands Task 2", Category.Errands, false));
        taskManager.AddTask(new TaskItem("Other Task 1", "Other Task Decription 1", Category.Other, true));
        taskManager.AddTask(new TaskItem("Other Task 2", "Other Task Decription 2", Category.Other, false));
        
        await taskManager.SyncTasks();
        // Task.Run(async () =>
        // {
        //     await saveTask(taskManager);
        // }).GetAwaiter().GetResult();

        while (true){

            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Print Tasks");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice){
                    case 1:
                        Console.Write("\nEnter task name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        string description = Console.ReadLine();
                        Console.Write("Enter task category (Personal, Work, Errands, Other): ");
                        if (Enum.TryParse(Console.ReadLine(), out Category category))
                        {
                            Console.Write("Is the task completed? (true/false): ");
                            if (bool.TryParse(Console.ReadLine(), out bool isCompleted)){
                                TaskItem task = new TaskItem(name, description, category, isCompleted);
                                taskManager.AddTask(task);
                                Console.WriteLine("Task Saved !");
                            }
                            else{
                                Console.WriteLine("Invalid input for task completion status.");
                            }
                        }
                        else{
                            Console.WriteLine("Invalid input for task category.");
                        }
                        break;

                    case 2:
                        Console.Write("\n Enter a category to filter tasks (Personal, Work, Errands, Other): ");
                        if (Enum.TryParse(Console.ReadLine(), out Category cat)){
                            taskManager.PrintTasks(cat);
                        }else{
                            taskManager.PrintTasks();
                        }
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }else{
                Console.WriteLine("Invalid input");
            }
        }
        // Task.Run(async () =>
        // {
        //     await saveTask(taskManager);
        // }).GetAwaiter().GetResult();
        await taskManager.SyncTasks();
    }

    // public static async void loadTasks(TaskManager taskManager){
    //     await taskManager.LoadTasks();
    // }

    // public static async void saveTask(TaskManager taskManager){
    //     await taskManager.SyncTasks();
    // }

}