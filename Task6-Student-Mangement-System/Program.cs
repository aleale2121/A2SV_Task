using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(){
    
        var studentList = new StudentList<Student>();

        await studentList.DeserializeFromJson();

        while (true)
        {
            Console.WriteLine("Choose From The Menu:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Print Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter student age: ");
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            Console.Write("Enter student grade: ");
                            char grade = Console.ReadLine().FirstOrDefault();
                            var student = new Student(name, age, grade);
                            studentList.Add(student);
                            Console.WriteLine("Student added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid age input.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter student name (leave empty for any): ");
                        string stuName = Console.ReadLine();
                        Console.Write("Enter student ID (leave empty for any): ");
                        if (int.TryParse(Console.ReadLine(), out int id)){
                            var searchResults = studentList.SearchStudent(stuName, id);
                            Console.WriteLine("Search Results:");
                            foreach (var result in searchResults){
                                Console.WriteLine($"ID:{result.ID} Name: {result.Name}, Age: {result.Age}, Grade: {result.Grade}, RollNumber: {result.RollNumber}");
                            }
                        }else{
                            Console.WriteLine("Invalid ID input.");
                        }

                        break;

                    case 3:
                        studentList.PrintStudents();
                        break;

                    case 4:
                        await studentList.SerializeToJson();
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric choice.");
            }
        }
    }
}
