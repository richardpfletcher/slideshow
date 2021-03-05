using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using Stories.Factory;
using System.Web.Http.Cors;

namespace Stories.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SpecificStoryDropdownController : ApiController
    {

        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetSpecificStoryDropdown();



        }

        [Route("api/specificStoryDropdown/getjatakabyyspecific")]

        public response getjatakabyyspecific(int id)
        {

            GetStories myStories = new GetStories();
            return myStories.GetSpecificStoryDropdownByCategory(id);



        }

    }
}
