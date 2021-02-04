using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using SharedLibrary.Data;

namespace GrpcVsRest
{
    public class RestClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Student> GetSmallPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var id = "5eeffdd1a28671a6e62dbda2";
            return await client.GetFromJsonAsync<Student>($"http://localhost:6000/api/studentapi/{id}");
        }
    }
}