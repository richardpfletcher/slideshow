using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stories.Models;
using Stories.Factory;
using System.Web.Http.Cors;
//using System.Web.Mvc;

namespace Stories.Controllers
{

    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[EnableCors(origins: "http://localhost:5199", headers: "*", methods: "*")]

    public class StoriesapiController : ApiController
    {

        [HttpPost]
        [Route("api/Storiesapi/insert")]

        public HttpResponseMessage Insert(Story myStoryies)
        {
            GetStories myStories = new GetStories();



            int lastRecord =myStories.Insert(myStoryies);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }

        [HttpPost]
        [Route("api/Storiesapi/inserturl")]

        public HttpResponseMessage InsertURL(youTubeModel myYoutube)
        {
            GetStories myStories = new GetStories();



            int lastRecord = myStories.InsertURL(myYoutube);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }


        [HttpPost]
        [Route("api/Storiesapi/deleteurl")]

        public HttpResponseMessage DeleteURL(youTubeModel myYoutube)
        {
            GetStories myStories = new GetStories();



            int lastRecord = myStories.DeleteURL(myYoutube);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }



        [HttpPost]
        [Route("api/Storiesapi/update")]

        public HttpResponseMessage Update(Story myStoryies)
        {
            GetStories myStories = new GetStories();



            int lastRecord = myStories.Update(myStoryies);
            MyOder order = new MyOder();
            order.MyData = lastRecord.ToString();
            //order.MyData = "1";
            return Request.CreateResponse<MyOder>(HttpStatusCode.Created, order);


        }

        [HttpPost]
        [Route("api/Storiesapi/search")]



        public string Search(Story myStoryies)
        //public HttpResponseMessage Search(Story myStoryies)
       
        //public response Search(Story myStoryies)
            //public string Search(Story myStoryies)
        {

            //return "hello";

            GetStories myStories = new GetStories();
            //SpecificStoryList mySpecificStoryList = new SpecificStoryList();
            string xmlString = myStories.GetSpecificStory(myStoryies);

            //response myresponse = new response();
            //myresponse = myStories.GetSpecificStory(myStoryies);

            //return myresponse ;
            return xmlString;
            //return Request.CreateResponse<String>(HttpStatusCode.Created, xmlString);

            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new StringContent(xmlString);
            //return response;

            //return myStories.GetSpecificStory(myStoryies);


        }


    }
}
