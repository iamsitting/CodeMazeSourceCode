using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using RESTvsGRPC.Models;

namespace RESTvsGRPC
{
    public class RestClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<string> GetSmallPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var payload = new RequestBody(){Id="5eeffdd1a28671a6e62dbda2"};
            var response = await client.PostAsJsonAsync("https://localhost:6001/api/studentapi", payload);
            return await response.Content.ReadAsStringAsync();
        }
    }
}