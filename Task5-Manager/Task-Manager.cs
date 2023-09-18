using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace TaskManager;

public class TaskManager
{
    public IList<TaskItem> tasks = new List<TaskItem>();
    private string _path="tasks_db.csv";

    public async Task LoadTasks(){
        try{
            using (StreamReader reader = new StreamReader(_path)){
                string line;
                while ((line = await reader.ReadLineAsync()) != null){
                    string[] splitted = line.Split(',');
                    string name = splitted[0];
                    string description = splitted[1];
                    if (Enum.TryParse(splitted[2], out Category category) &&
                        bool.TryParse(splitted[3], out bool isCompleted)){
                        TaskItem task = new TaskItem(name, description, category, isCompleted);
                        tasks.Add(task);
                    }
                }
            }
            Console.WriteLine("Tasks loaded successfully.");
        } catch (IndexOutOfRangeException ex){
            Console.WriteLine($"{ex.Message}");
        } catch (IOException ex){
            Console.WriteLine($"{ex.Message}");
        } catch (Exception ex){
            Console.WriteLine($"{ex.Message}");
        }
    }

    public void AddTask(TaskItem task){
        tasks.Add(task);
    }

    public void PrintTasks(Category? category=null){
        IEnumerable<TaskItem> results = tasks;

        if (category.HasValue){
            results = results.Where(task => task.Category == category);
        }
        if (results.Any()){

            Console.WriteLine($"<---->Tasks <---->");
            foreach (var task in results){
                Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {(Category)task.Category}, Status: {task.GetStatus()}");
            }

        }else{
            Console.WriteLine("no result found.");
        }

    }

    public async Task SyncTasks(){
        try{
            using (StreamWriter writer = new StreamWriter(_path)){
                foreach (var task in tasks){
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                }
            }
        }catch (IOException ex){
            Console.WriteLine($" {ex.Message}");
        }catch (Exception ex){
            Console.WriteLine($"{ex.Message}");
        }
    }

}