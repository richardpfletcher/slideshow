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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AnimalTypeController : ApiController
    {


        public response Get()
        {

            GetStories myStories = new GetStories();
            return myStories.GetAnimal();



        }

     

        [HttpPost]
        [Route("api/AnimalType/updateAnimal")]

        public HttpResponseMessage updateAnimal(AnimalTypes myAnimalTypes)
        {
            
            GetStories myStories = new GetStories();
            int lastRecord = myStories.updateAnimal(myAnimalTypes.ID, myAnimalTypes.AnimalType);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }

    }
}
