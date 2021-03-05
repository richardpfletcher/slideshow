using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Stories.Controllers
{
   
        // GET: Login
        public class LoginController : ApiController
        {
            [System.Web.Http.HttpPost]
            [System.Web.Http.Route("Login")]
            public JObject loginService([FromBody] JObject loginJson)
            {
                JObject retJson = new JObject();
                string username = loginJson["username"].ToString();
                string password = loginJson["password"].ToString();
                if (username == "admin" && password == "admin")
                {
                    retJson.Add(new JProperty("authentication ", "successful"));
                }
                else
                {
                    retJson.Add(new JProperty("authentication ", "unsuccessful"));
                }
                return retJson;
            }
        }

   
   
}