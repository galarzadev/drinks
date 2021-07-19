using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace drinks.Service
{
    public class SendRequest<T> where T: Models.IRequestable
    {
        private HttpClient _client = new HttpClient();
        public async Task<T> Send(T model)
        {
            string url = "https://jsonplaceholder.typicode.com/posts/";

            var data = JsonSerializer.Serialize<T>(model);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync(url, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();

                var postResult = JsonSerializer.Deserialize<T>(result);
                return postResult;
            }
            else
            {
                Console.WriteLine("no se pudo");
            }
            return default(T);
        }
    }
}
