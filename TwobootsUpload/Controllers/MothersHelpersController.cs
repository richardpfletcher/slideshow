using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stories.Factory;
using System.Web.Http.Cors;
using Stories.Models;


namespace Stories.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MothersHelpersController : ApiController
    {

        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetMothersHelpers();



        }

        [Route("api/MothersHelpers/updateRoles")]

        public HttpResponseMessage UpdateRoles(useRoles myuseRoles)
        {

            GetStories myStories = new GetStories();

            int lastRecord = myStories.UpdateRoles(myuseRoles);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);

        }

        [Route("api/MothersHelpers/getMothersHelpersType")]

        public response GetMothersHelpersType()
        {

            GetStories myStories = new GetStories();
            return myStories.GetMothersHelpersType();



        }


        [Route("api/MothersHelpers/getMothersHelpersTypeSpecific")]

        public response GetMothersHelpersTypeSpecific(int id)
        {

            GetStories myStories = new GetStories();
            return myStories.GetMothersHelpersTypeSpecific(id);



        }


        [Route("api/MothersHelpers/getMothersHelpersTypeUsers")]

        public response GetMothersHelpersTypeUsers(int id)
        {

            GetStories myStories = new GetStories();
            return myStories.GetMothersHelpersTypeUsers(id);



        }

        [Route("api/MothersHelpers/getMothersEmail")]

        public response GetMothersEmail(int id)
        {

            GetStories myStories = new GetStories();
            return myStories.GetMothersEmail(id);



        }


    }
}
