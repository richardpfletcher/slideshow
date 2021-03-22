using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cook.Models;
using Cook.API;
using System.Net.Mail;
using heartoflove.Models;
using Stories.Factory;

namespace whatscooking.Controllers
{
    public class HomeController : Controller
    {

        private void LogEntry(string text)
        {
            //var folder = @"C:\Users\Richard\Google Drive\projects\SlideShow\WebApplication2\App_Data";
            var folder = @"C:\Users\Richard\Google Drive\WebSites\kylah\App_Data";
            var logfilename = $@"{folder}\logs.txt";
            if (System.IO.Directory.Exists(folder))
                System.IO.File.AppendAllText(logfilename, $"{DateTime.Now}\t{text}\r\n");
        }

        public ActionResult Index()
        {

            try
            { 

            
            Stories.Factory.response items1 = new Stories.Factory.response();

            GetLookups myGetLookups = new GetLookups();
            items1 = myGetLookups.GeLookupAnimal();

            GetStories myGetStories = new GetStories();
            string fileName = myGetStories.GetUpdateBackgroundSound();
            ViewData["BackgroundSound"] = fileName;

            Stories.Factory.AnimalTypeList MyFavoritesModel = new Stories.Factory.AnimalTypeList();

            //var x = items1.data[0];
            MyFavoritesModel =  items1.data[0] as Stories.Factory.AnimalTypeList;

            List<Stories.Factory.AnimalTypeList> myList = new List<Stories.Factory.AnimalTypeList>();
            AnimalTypeList list = new AnimalTypeList();

            for (int i = 0; i < MyFavoritesModel.animalTypeLists.Count; i++)
            {
                animalType myanimalType = new animalType();
                myanimalType.RECEIPTNO = MyFavoritesModel.animalTypeLists[i].RECEIPTNO;
                myanimalType.Title = MyFavoritesModel.animalTypeLists[i].Title;
                myanimalType.Comments = MyFavoritesModel.animalTypeLists[i].Comments;
                myanimalType.Picture = MyFavoritesModel.animalTypeLists[i].Picture;
                myanimalType.url = MyFavoritesModel.animalTypeLists[i].url;
                list.animalTypeLists.Add(myanimalType);
            }


           

                //ViewData["MyFavortiesData"] = items1.data[0];
                ViewData["MyFavortiesData"] = list;


            string firstOne = null;




                //foreach (MyFavoritesModel s in items1)
                //{
                //    firstOne = s.Title;
                //    firstOne = firstOne.Substring(0, 1);
                //    ViewData["firstOne"] = firstOne;
                //    break;
                //}

            }
            catch (Exception ex)
            {
                LogEntry(ex.ToString());//replace with something like Serilog
                throw;
            }

            return View();
        }

        [ValidateInput(false)]
        public ActionResult Comments(EmailModel model)
        {
            string emailLoggedIn = "";

            try
            {
                if (Request.IsAuthenticated)
                {
                    //MembershipUser mu = Membership.GetUser();
                    //emailLoggedIn = mu.UserName;
                    emailLoggedIn = User.Identity.Name;
                    model.Email = emailLoggedIn;
                }
            }
            catch
            {
                emailLoggedIn = ""; //user logged in
                //return View(); //user not logeed in
            }

            ViewData["emailLoggedIn"] = emailLoggedIn;

            ViewData["message"] = "";

            if (ModelState.IsValid)
            {
                CommentsPost(model);
            }

            return this.View(model);
        }

        //MenuPlanner

        [ValidateInput(false)]

        public ActionResult CommentsPost(EmailModel model)
        {

            SmtpClient smtpClient = new SmtpClient();
            string EmailFrom = model.Email;
            string EmailTo = "richardpfletcher@gmail.com";

            try
            {
                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    using (var message = new MailMessage(EmailFrom, EmailTo))
                    {
                        message.Subject = "mexican.today Comments from user " + model.Email;
                        message.Body = model.Comments;
                        MailAddress bcc = new MailAddress(EmailFrom);
                        message.CC.Add(bcc);

                        message.IsBodyHtml = true;
                        client.UseDefaultCredentials = false;


                        client.Credentials = new System.Net.NetworkCredential("richardpfletcher@gmail.com", "Barbara_1111");


                        client.EnableSsl = true;
                        client.Send(message);
                    };
                };
            }
            catch (Exception ex)
            {
                string x = ex.ToString();
                throw;
            }

            ViewData["message"] = "Email is sent";

            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}