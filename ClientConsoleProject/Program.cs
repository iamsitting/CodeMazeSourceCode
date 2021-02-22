using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
namespace ClientConsoleProject
{
    public class Program
    {
        public static async Task Main()
        {
            using (var client = new HttpClient())
            {
                var student = await client.GetFromJsonAsync<Student>("https://localhost:5001/student");
                var studentJson = JsonSerializer.Serialize<Student>(student);
                Console.WriteLine($"{studentJson}");
            }
        }
    }
}
