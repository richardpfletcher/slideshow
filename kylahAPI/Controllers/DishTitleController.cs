using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stories.Factory;
using System.Web.Http.Cors;
using Stories.Models;
using Stories.Factory;


namespace Stories.Controllers
{
    public class DishTitleController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]



        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetDishTitle();




        }



    }
}
