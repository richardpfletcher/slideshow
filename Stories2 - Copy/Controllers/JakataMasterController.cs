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
    public class JakataMasterController : ApiController
    {

        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetJakataMaster();



        }

        [HttpPost]
        [Route("api/JakataMasterype/updateJakata")]

        public HttpResponseMessage updateJakata(JakataMaster myJakataMaster)
        {

            GetStories myStories = new GetStories();
            int lastRecord = myStories.JakataMaster(myJakataMaster);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }


       
        [Route("api/JakataMasterype/JakataMasterFilter")]

        public response GetJakataMasterFilter()
        {

            GetStories myStories = new GetStories();
            return myStories.GetJakataMasterFilter();



        }

    }
}
