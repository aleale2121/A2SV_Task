using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



public class StudentList<T> where T : Student{
    private IList<T> students = new List<T>();
    private const string _fileName="students.json";

    public void Add(T student){
        students.Add(student);
    }

    public IEnumerable<T> SearchStudent(string name = null, int? id = null)
    {
        var query = from student in students
                    where (string.IsNullOrEmpty(name) || student.Name == name) &&
                        (!id.HasValue || student.ID == id)
                    select student;

        return query;
    }

    public void PrintStudents(){
        foreach (var student in students)
        {
            var properties = student.GetType().GetProperties();
            Console.WriteLine("Student Information:");
            foreach (var property in properties)
            {
                var value = property.GetValue(student);
                Console.WriteLine($"{property.Name}: {value}");
            }
            Console.WriteLine();
        }
    }

    public async Task SerializeToJson()
    {
        string jsonString = JsonSerializer.Serialize(students, new JsonSerializerOptions{
            WriteIndented = true
        });
        File.WriteAllText(_fileName, jsonString);
    }

    public async Task<StudentList<T>> DeserializeFromJson()
    {
        
        string jsonString = await File.ReadAllTextAsync(_fileName);
        List<T> deserializedStudents = JsonSerializer.Deserialize<List<T>>(jsonString);
        students = deserializedStudents;
        return this;
    }

}