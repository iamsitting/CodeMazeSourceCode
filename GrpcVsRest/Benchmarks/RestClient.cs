using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibrary.Rest;

namespace GrpcVsRest
{
    public class RestClient
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<string> GetSmallPayloadAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var payload = new RequestBody(){Id="5fe3a38292267c002b8a376c"};
            var response = await client.PostAsJsonAsync("http://localhost:6000/api/studentapi", payload);
            return await response.Content.ReadAsStringAsync();
        }
    }
}