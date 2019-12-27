using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmarterMailCodeSamples.Models
{
    public class AuthenticationInput
    {
        /// <summary>
        /// The user's username or email address. [Required, Minimum Length 0, Maximum Length 200]
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// The user's password. [Required, Minimum Length 0, Maximum Length 200]
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// The user's selected language.
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// The user's two step code provided by their selected two step method.
        /// </summary>
        public string twoFactorCode { get; set; }
        /// <summary>
        /// A token given when a user attempts to log in and is forced to setup two factor.
        /// Pass to two factor setup methods when the user does not have a auth token.
        /// </summary>
        public string twoFactorSetupGuid { get; set; }
        /// <summary>
        /// If true the login will return a autologin token instead of a regular auth token.
        /// This token is valid for 1 minute.
        /// </summary>
        public bool retrieveAutoLoginToken { get; set; }
        /// <summary>
        /// A auto login token that can be used in a url formatted like '{Root Url}/interface/autologin?autologin={Token}' to auto login.
        /// This token is valid for 1 minute.
        /// </summary>
        public string autoLoginToken { get; set; }
    }
}
