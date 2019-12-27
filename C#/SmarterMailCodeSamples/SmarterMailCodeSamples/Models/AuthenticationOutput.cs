using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmarterMailCodeSamples.Models
{
    public class AuthenticationOutput
    {
        /// <summary>
        /// The user's email address.
        /// </summary>
        public string emailAddress { get; set; }
        /// <summary>
        /// If true the user will be required to change their password before they can login.
        /// </summary>
        public bool changePasswordNeeded { get; set; }
        /// <summary>
        /// If true the user will be redirected to the welcome wizard.
        /// </summary>
        public bool displayWelcomeWizard { get; set; }
        /// <summary>
        /// If true the user is a system administrator.
        /// </summary>
        public bool isAdmin { get; set; }
        /// <summary>
        /// If true the user is a domain administrator.
        /// </summary>
        public bool isDomainAdmin { get; set; }
        /// <summary>
        /// If true the server is licensed.
        /// </summary>
        public bool isLicensed { get; set; }
        /// <summary>
        /// A auto login token that can be used in a url formatted like '{Root Url}/interface/autologin?autologin={Token}' to auto login.
        /// This token is valid for 1 minute.
        /// </summary>
        public string autoLoginToken { get; set; }
        /// <summary>
        /// A url containing the auto login token that can be used to login.
        /// This url is valid for 1 minute.
        /// </summary>
        public string autoLoginUrl { get; set; }
        /// <summary>
        /// If true the user is currently impersonating another user.
        /// </summary>
        public bool isImpersonating { get; set; }
        /// <summary>
        /// If true the impersonating admin can view the user's password
        /// </summary>
        public bool canViewPasswords { get; set; }
        /// <summary>
        /// The security access token used to validate a user's session.
        /// </summary>
        public string accessToken { get; set; }
        /// <summary>
        /// The security refresh token used to obtain new access and refresh tokens.
        /// </summary>
        public string refreshToken { get; set; }
        /// <summary>
        /// The date timestamp when the access token will expire.
        /// </summary>
        public DateTime accessTokenExpiration { get; set; }
        /// <summary>
        /// The user's username.
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// If true the function call succeeded. [Required]
        /// </summary>
        public bool success { get; set; }
        public HttpStatusCode resultCode { get; set; }
        /// <summary>
        /// If success is false, this field tells you why the call failed.
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// Will sometimes contain additional info relating to a call.
        /// </summary>
        public string debugInfo { get; set; }
    }
}
