using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using facebookapp.Models;
//using facebookapp.App_Start;
using WebApplication2;

namespace facebookapp
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

          

            //OAuthWebSecurity.RegisterClient(new FacebookClient("499578783419700", "a315451fbe3981765103cb1b324dad37"));

            OAuthWebSecurity.RegisterClient(new GooglePlusClient("610406505706-paeb9v7t8forrsbtbt5tu1q2n84gu5ov.apps.googleusercontent.com", "leqqkWu3weIcyYb2iaQQh8Py"), "Google+", null);

        }
    }
}
