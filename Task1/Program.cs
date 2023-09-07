Console.Write("Enter Your Name: ");
string studentName=Console.ReadLine();
Console.Write("Enter The Number Of Subjects: ");
int noSubject;
while (true){
    if (int.TryParse(Console.ReadLine(), out noSubject)){
        if (noSubject < 0){
            Console.WriteLine("Number of Subject must be a positive number.");

        }else{
            break;
        }
    }else{
        Console.WriteLine("Invalid input: Enter numeric number of subject only.");
    }

}
List<string> subjects = new List<string>();
Dictionary<string, double> grades = new Dictionary<string, double>();

for (int i = 0; i < noSubject; i++)
{
    Console.Write($"Enter the name of subject #{i + 1}: ");
    string name=Console.ReadLine();
    double grade;
    while (true){
        Console.Write($"Enter the grade for {name}: ");

        if (double.TryParse(Console.ReadLine(), out grade)){
            if (grade < 0 || grade > 100){
                Console.WriteLine("Grade must be in range 0 - 100.");
            }else{
                break;
            }
        }else{
            Console.WriteLine("Invalid input: Enter numeric grade only.");
        }
    }
    grades.Add(name, grade);
    subjects.Add(name);

}

double total = 0;
foreach (var grade in grades.Values){
    total+=grade;
}
double average=total/noSubject;

Console.WriteLine($"\nStudent Name: {studentName}");
Console.WriteLine("Subject Grades:");
foreach (var subject in subjects){
    Console.WriteLine($"{subject}: {grades[subject]}");
}
Console.WriteLine($"Average: {average:F2}");
    

