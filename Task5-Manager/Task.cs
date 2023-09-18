namespace TaskManager;

public class TaskItem{
    public string Name {get;set;}
    public string Description {get;set;}
    public Category Category {get;set;}
    public bool IsCompleted {get;set;}

    public TaskItem(string name, string description, Category category, bool isCompleted){
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = isCompleted;
    }

    public string GetStatus(){
        return IsCompleted ? "Completed" : "Not Completed";
    }
}