using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stories.Models;
using Stories.Factory;
using System.Web.Http.Cors;

namespace Stories.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StoriesController : ApiController
    {

        [HttpGet]

        [Route("api/Stories/getSpecificStory")]

        public response Get(int ID, string mode)
        {

            GetStories myStories = new GetStories();
            return myStories.GetSpecificStory(ID, mode);
        }
    }
}
