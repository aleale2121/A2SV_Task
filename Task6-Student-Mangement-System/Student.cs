public class Student{
    public int ID {get; private set;}
    public string Name { get; set; }
    public int Age { get; set; }
    public  int RollNumber { get; }
    public char Grade { get; set; }

    private static int nextID = 1;
    private readonly int _rollNumber;


    public Student(string name, int age, char grade){
        ID = nextID;
        Name = name;
        Age = age;
        _rollNumber = nextID; 
        RollNumber = _rollNumber;
        Grade = grade;
        nextID++;
    }
}
