using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SmarterMailCodeSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmarterMailCodeSamples.Services
{
    public interface IAuthentication
    {
        Task<AuthenticationOutput> AuthenticateUser(AuthenticationInput input);
    }

    public class Authentication : IAuthentication
    {
        private readonly HttpClient _client;
        public Authentication(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _client = clientFactory.CreateClient();
            _client.BaseAddress = new Uri(config.GetValue<string>("SmarterMailBaseUrl"));
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<AuthenticationOutput> AuthenticateUser(AuthenticationInput input)
        {
            var res = await _client.PostAsync(
                "/api/v1/auth/authenticate-user",
                new StringContent(JsonConvert.SerializeObject(input),
                    Encoding.UTF8,
                    "application/json"
                )
            );
            res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadAsStringAsync();
            AuthenticationOutput data = JsonConvert.DeserializeObject<AuthenticationOutput>(result);

            // You can now access all data like the access token with data.KEY_NAME (e.g. data.accessToken)

            return data;
        }
    }
}
