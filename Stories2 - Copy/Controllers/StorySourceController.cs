using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stories.Factory;
using System.Web.Http.Cors;

namespace Stories.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StorySourceController : ApiController
    {
        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetStorySource();



        }

    }
}
