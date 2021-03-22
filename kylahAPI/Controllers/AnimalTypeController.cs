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

        private void LogEntry(string text)
        {
            //var folder = @"C:\Users\Richard\Google Drive\projects\SlideShow\WebApplication2\App_Data";
            var folder = @"C:\Users\Richard\Google Drive\WebSites\kylahAPI\App_Data";
            var logfilename = $@"{folder}\logs.txt";
            if (System.IO.Directory.Exists(folder))
                System.IO.File.AppendAllText(logfilename, $"{DateTime.Now}\t{text}\r\n");
        }

        public response Get()
        {

           

            try
            {

                GetStories myStories = new GetStories();
                return myStories.GetAnimal();
            }
            catch (Exception ex)
            {
                LogEntry(ex.ToString());//replace with something like Serilog
                throw;
            }
            //return View();



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
