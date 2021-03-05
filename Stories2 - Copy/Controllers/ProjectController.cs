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

    public class ProjectController : ApiController
    {

        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetPosted();



        }

        [HttpGet]

        [Route("api/Project/getReadersSpecificStory")]

        public response GetReadersSpecificStory(int id)
        {

            GetStories myStories = new GetStories();
            return myStories.GetReadersSpecificStory(id);


        }

        [HttpGet]

        [Route("api/Project/getReaderstory")]

        public response GetReadersStory(int JakataID, int userID)
        {

            GetStories myStories = new GetStories();
            return myStories.GetReadersStory(JakataID, userID);


        }

        [HttpPost]

        [Route("api/Project/save")]

        public int Save(readersStory myStory)
        {

            GetStories myStories = new GetStories();
            return myStories.Save(myStory);


        }


    }
}
