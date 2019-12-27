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
        Task<RefreshTokenOutput> RefreshToken(RefreshTokenInput input);
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

        /// <summary>
        /// This function will attempt to authenticate the username and password against the SmarterMail server.
        /// The language string that gets passed in with the login variables should be written in C# standard locale formats.
        /// A complete list can be found by searching for 'C# CultureInfo list' with your desired search engine.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        /// <summary>
        /// This function will attempt to generate new access and refresh tokens.
        /// This function takes in the current refresh token, that was generated at login, and validates it.
        /// If the refresh token is valid this function will return a new set of access and refresh tokens. 
        /// The new access token will need to be placed in the request header in the following format:
        /// Authorization: Bearer eyJ0eXAiOiJKV1QiL.....
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<RefreshTokenOutput> RefreshToken(RefreshTokenInput input)
        {
            var res = await _client.PostAsync(
                "/api/v1/auth/refresh-token",
                new StringContent(JsonConvert.SerializeObject(input),
                    Encoding.UTF8,
                    "application/json"
                )
            );
            res.EnsureSuccessStatusCode();

            var result = await res.Content.ReadAsStringAsync();
            RefreshTokenOutput data = JsonConvert.DeserializeObject<RefreshTokenOutput>(result);

            // You can now access all data like the access token with data.KEY_NAME (e.g. data.accessToken)

            return data;
        }
    }
}
