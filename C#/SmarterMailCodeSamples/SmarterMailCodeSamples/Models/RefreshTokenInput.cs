using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmarterMailCodeSamples.Models
{
    public class RefreshTokenInput
    {
        /// <summary>
        /// The security refresh token used to obtain new access and refresh tokens.
        /// [Required, Minimum Length 0, Maximum Length 1000]
        /// </summary>
        public string token;
    }
}
