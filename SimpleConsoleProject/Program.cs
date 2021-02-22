using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace SimpleConsoleProject
{
    public class Program
    {
        public static void Main()
        {
            var student = new Student()
            {
                Name = "John Doe",
                Grade = 10,
                LastLoggedIn = DateTime.Today,
                Major = Major.Arts,
                Enrolled = true
            };
            var options = new JsonSerializerOptions()
            {
                IncludeFields = true
            };
            Console.WriteLine($"Object: {student}");
            var studentJson = JsonSerializer.SerializeToUtf8Bytes<Student>(student, options);
            Console.WriteLine($"JSON: {studentJson}");
            var deserializedStudent = JsonSerializer.Deserialize<Student>(studentJson, options);
            Console.WriteLine($"Deserialized: {deserializedStudent}");
            var reserializedStudent = JsonSerializer.Serialize<Student>(deserializedStudent);
            Console.WriteLine($"Reserialized: {reserializedStudent}");
        }
    }
}
