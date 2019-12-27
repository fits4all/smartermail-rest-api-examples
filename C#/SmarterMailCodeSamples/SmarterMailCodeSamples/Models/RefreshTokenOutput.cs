using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmarterMailCodeSamples.Models
{
    public class RefreshTokenOutput
    {
        /// <summary>
        /// If true the user is currently impersonating another user.
        /// </summary>
        public bool isImpersonating;
        /// <summary>
        /// If true the impersonating admin can view the user's password
        /// </summary>
        public bool canViewPasswords;
        /// <summary>
        /// The security access token used to validate a user's session.
        /// </summary>
        public string accessToken;
        /// <summary>
        /// The security refresh token used to obtain new access and refresh tokens.
        /// </summary>
        public string refreshToken;
        /// <summary>
        /// The date timestamp when the access token will expire.
        /// </summary>
        public DateTime accessTokenExpiration;
        /// <summary>
        /// The user's username.
        /// </summary>
        public string username;
        /// <summary>
        /// If true the function call succeeded. [Required]
        /// </summary>
        public bool success;
        public HttpStatusCode resultCode;
        /// <summary>
        /// If success is false, this field tells you why the call failed.
        /// </summary>
        public string message;
        /// <summary>
        /// Will sometimes contain additional info relating to a call.
        /// </summary>
        public string debugInfo;
    }
}
