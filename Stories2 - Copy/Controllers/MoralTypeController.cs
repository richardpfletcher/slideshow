using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using Stories.Factory;
using System.Web.Http.Cors;
using Stories.Models;

namespace Stories.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MoralTypeController : ApiController
    {
        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetMoralType();

        }

        [HttpPost]
        [Route("api/MoralType/updateMoral")]

        public HttpResponseMessage updateMoral(MoralTypes myMoralTypes)
        {

            GetStories myStories = new GetStories();
            int lastRecord = myStories.updateMoralType(myMoralTypes.ID, myMoralTypes.MoralType);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }
    }
}
