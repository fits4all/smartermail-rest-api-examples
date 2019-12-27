using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmarterMailCodeSamples.Models;
using SmarterMailCodeSamples.Services;

namespace SmarterMailCodeSamples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthentication _auth;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthentication auth)
        {
            _logger = logger;
            _auth = auth;
        }

        [HttpGet]
        public async Task<AuthenticationOutput> Get()
        {
            var data = new AuthenticationInput
            {
                username = "demoadmin",
                password = "Login123"
            };
            
            AuthenticationOutput result = await _auth.AuthenticateUser(data);

            // You can now access all data like the access token with result.KEY_NAME (e.g. result.accessToken)

            return result;
        }

        [HttpGet("refresh")]
        public async Task<RefreshTokenOutput> RefreshToken()
        {
            var data = new RefreshTokenInput
            {
                token = "ey......" // enter your refresh token here
            };

            RefreshTokenOutput result = await _auth.RefreshToken(data);

            // You can now access all data like the access token with result.KEY_NAME (e.g. result.accessToken)

            return result;
        }
    }
}
