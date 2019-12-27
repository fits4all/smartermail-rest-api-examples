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

            return result;
        }
    }
}
