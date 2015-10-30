using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace swaggerclientgenerator.Templates
{
    public class SampleClient
    {
        private readonly ApiConfig config;
        private readonly HttpClient client;

        public SampleClient(ApiConfig config)
        {
            this.config = config;
            this.client = config.CreateClient();
        }

        public async Task<object> GetObject(object parameter)
        {
            var response = await client.GetAsync(string.Empty);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            var result = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }

    public class ApiConfig
    {
        public ApiConfig(string endpoint,
            Dictionary<string, string> defaultHeaders = null)
        {
            Endpoint = endpoint;
            DefaultHeaders = defaultHeaders;
        }

        public string Endpoint { get; }
        public Dictionary<string, string> DefaultHeaders { get; }

        public HttpClient CreateClient()
        {
            var client = new HttpClient {BaseAddress = new Uri(Endpoint)};

            foreach (var header in DefaultHeaders ?? new Dictionary<string, string>())
                client.DefaultRequestHeaders.Add(header.Key, header.Value);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
