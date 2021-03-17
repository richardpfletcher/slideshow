
using System.Web.Mvc;
using Stories.Factory;

using Stories.Models;
using Dapper;
//using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mime;
using MvcContrib.Filters;


namespace Stories.Controllers
{

    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            
            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();


            model = myGetLookups.GeLookupCatUsers(0);
            //model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

            ViewData["newReadersData"] = model.items;

            GetStories myGetStories = new GetStories();
            string fileName = myGetStories.GetUpdateBackgroundSound();
            ViewData["BackgroundSound"] = fileName;

            return View();
        }

        public ActionResult Coupon()
        {
            ViewBag.Title = "Home Page";


            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();


            model = myGetLookups.GeLookupCatUsers(0);

            ViewData["newReadersData"] = model.items;

            DropdownModel modelDish = new DropdownModel();
            modelDish = myGetLookups.GetDishTitle();
            ViewData["newdishData"] = modelDish.items;

            GetStories myGetStories = new GetStories();
            string fileName = myGetStories.GetUpdateBackgroundSound();
            ViewData["BackgroundSound"] = fileName;

            DropdownModel modelDay = new DropdownModel();

            modelDay.items.Add(new SelectListItem { Text = "Please Select", Value = "0" });

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            for (int i = 0; i < daysOfWeek.Length; i++)
            {

                modelDay.items.Add(new SelectListItem { Text = daysOfWeek[i], Value = daysOfWeek[i] });
            }

            ViewData["daysOfWeek"] = modelDay.items;


            return View();
        }


        public ActionResult CouponUpdateFinal(FormCollection form)
        {
            string ID = base.Request.Form["ID"];
            string titleCoupon = base.Request.Form["TitleCoupon"];
            string urlCoupon = base.Request.Form["urlCoupon"];
            string pictureCoupon = base.Request.Form["PictureCoupon"];
            string startDate = base.Request.Form["StartDate1"];
            string endDate = base.Request.Form["StopDate1"];
            string dayOfWeek = base.Request.Form["idDayOfWeek"];
            string dishID = base.Request.Form["dishID"];


            GetStories myGetStories = new GetStories();
            myGetStories.UpdateCoupon(Convert.ToInt32(ID), titleCoupon, urlCoupon, pictureCoupon, startDate, endDate, dayOfWeek, dishID);

            string mode = "save";
            Session["Mode"] = mode;
                     

            return RedirectToAction("CouponUpdate", "Home", new { ID = Convert.ToInt32(ID) });

           
        }


        public ActionResult CouponUpdate(int ID)
        {
            ViewData["ID"] = ID;

            Stories.Factory.response items1 = new Stories.Factory.response();

            GetLookups myGetLookups = new GetLookups();
            items1 = myGetLookups.GeLookupCoupon(ID);

            GetStories myGetStories = new GetStories();
            string fileName = myGetStories.GetUpdateBackgroundSound();
            ViewData["BackgroundSound"] = fileName;

            Stories.Factory.CouponList MyFavoritesModel = new Stories.Factory.CouponList();

            //var x = items1.data[0];
            MyFavoritesModel = items1.data[0] as Stories.Factory.CouponList;

            List<Stories.Factory.CouponList> myList = new List<Stories.Factory.CouponList>();
            CouponList list = new CouponList();

            coupon mycoupon = new coupon();

            for (int i = 0; i < MyFavoritesModel.couponLists.Count; i++)
            {
                mycoupon = new coupon();
                mycoupon.dayOfWeek = MyFavoritesModel.couponLists[i].dayOfWeek.Trim();
                mycoupon.endDate = MyFavoritesModel.couponLists[i].endDate;
                mycoupon.expired = MyFavoritesModel.couponLists[i].expired;
                mycoupon.id = MyFavoritesModel.couponLists[i].id;
                mycoupon.PictureCoupon = MyFavoritesModel.couponLists[i].PictureCoupon;
                mycoupon.DishID = MyFavoritesModel.couponLists[i].DishID;



                mycoupon.startDate = MyFavoritesModel.couponLists[i].startDate;
                mycoupon.TitleCoupon = MyFavoritesModel.couponLists[i].TitleCoupon;
                mycoupon.urlCoupon = MyFavoritesModel.couponLists[i].urlCoupon;
                

                list.couponLists.Add(mycoupon);

                //ViewData["RECEIPTNO"]
            }


            DropdownModel modelDay = new DropdownModel();

            modelDay.items.Add(new SelectListItem { Text = "Please Select", Value = "0" });

            string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            for (int i = 0; i < daysOfWeek.Length; i++)
            {

                modelDay.items.Add(new SelectListItem { Text = daysOfWeek[i], Value = daysOfWeek[i] });
            }

            //foreach (SelectListItem s in modelDay.items)
            //{
            //    if (s.Value == mycoupon.dayOfWeek.Trim())
            //    {
            //        s.Selected = true;
            //    }
            //}


            for (int i = 0; i < modelDay.items.Count(); i++)
            {

                //modelDish.items[i].Value

                if (modelDay.items[i].Value == mycoupon.dayOfWeek.Trim())
                {
                    modelDay.items[i].Selected = true;
                }

            }


            ViewData["daysOfWeek"] = modelDay.items;

            //ViewData["daysOfWeek"] = mycoupon.dayOfWeek;

            DropdownModel modelDish = new DropdownModel();
            modelDish = myGetLookups.GetDishTitle();

            for (int i = 0; i < modelDish.items.Count(); i++)
            {
                
                //modelDish.items[i].Value

                if (modelDish.items[i].Value == mycoupon.DishID)
                {
                    modelDish.items[i].Selected = true;
                }

            }



            ViewData["newdishData"] = modelDish.items;


            return View(mycoupon);
        }


        


        public ActionResult DishUpdateFinal(FormCollection form)
        {
            string ID = base.Request.Form["ID"];
            string title = base.Request.Form["title"];
            string url = base.Request.Form["url"];
            string picture = base.Request.Form["picture"];

            GetStories myGetStories = new GetStories();
            myGetStories.UpdateDish(Convert.ToInt32(ID), title, url, picture);
        
            string mode = "save";
            Session["Mode"] = mode;

            return RedirectToAction("DishUpdate", "Home", new { ID= Convert.ToInt32(ID) });

            //return View();
        }

        //[PassParametersDuringRedirect]
        //[AcceptGet]

        public ActionResult DishUpdate(int ID)
        {

            ViewData["ID"] = ID;

            Stories.Factory.response items1 = new Stories.Factory.response();

            GetLookups myGetLookups = new GetLookups();
            items1 = myGetLookups.GeLookupAnimal(ID);

            GetStories myGetStories = new GetStories();
            string fileName = myGetStories.GetUpdateBackgroundSound();
            ViewData["BackgroundSound"] = fileName;

            Stories.Factory.AnimalTypeList MyFavoritesModel = new Stories.Factory.AnimalTypeList();

            //var x = items1.data[0];
            MyFavoritesModel = items1.data[0] as Stories.Factory.AnimalTypeList;

            List<Stories.Factory.AnimalTypeList> myList = new List<Stories.Factory.AnimalTypeList>();
            AnimalTypeList list = new AnimalTypeList();

            animalType myanimalType = new animalType();

            for (int i = 0; i < MyFavoritesModel.animalTypeLists.Count; i++)
            {
                myanimalType = new animalType();
                myanimalType.RECEIPTNO = MyFavoritesModel.animalTypeLists[i].RECEIPTNO;
                myanimalType.Title = MyFavoritesModel.animalTypeLists[i].Title;
                myanimalType.Comments = MyFavoritesModel.animalTypeLists[i].Comments;
                myanimalType.Picture = MyFavoritesModel.animalTypeLists[i].Picture;
                myanimalType.url = MyFavoritesModel.animalTypeLists[i].url;
                list.animalTypeLists.Add(myanimalType);

                //ViewData["RECEIPTNO"]
            }


            return View(myanimalType);
        }


        public ActionResult Insert()
        {
            ViewBag.Message = "Your app description page.";

            


            return View();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public ActionResult Update(int row)
        {
            
            return View();
        }

        public ActionResult UpdateStory()
        {
            ViewBag.Message = "Your app description page.";
            



            return View();
        }

        public ActionResult UpdateProject()
        {
            ViewBag.Message = "Your app description page.";
            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();

            model = myGetLookups.GeLookupSpecificStoryDropdown();
            ViewData["jakataMasterData"] = model.items;



            model = myGetLookups.GeLookupCatUsers(2);
            model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

            //model.items.Add

            ViewData["newReadersData"] = model.items;

            DropdownModel modelExisting = new DropdownModel();
            ViewData["existingReaderData"] = modelExisting.items;







            return View();
        }

        [HttpPost]

        public ActionResult Project(int row, int userID, string userName, string mode)
        {


            ViewBag.Title = "Project";
            Story myStory = new Story();
            myStory.userName = userName;
            myStory.userID = userID;
            ViewData["userID"] = userID;
            myStory.Mode = mode;
            ViewData["Mode"] = mode;

            DropdownModel model = new DropdownModel();
            DropdownModel modelAnimal = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();
            model = myGetLookups.GeLookupPosted();
            myStory.Posted = model;
            myStory = myGetLookups.GetReaderstory(row, userID);

            //var title = JakataID.ToString();

            foreach (SelectListItem s in model.items)
            {
                if (s.Value == myStory.PostedString)
                {
                    s.Selected = true;
                }
            }



            ViewData["postedData"] = model.items;

            //ilustrators

            //model = myGetLookups.GeLookupCatUsers(1);
            model = myGetLookups.GeLookupCatUsers(1);

            if (mode == "edit")
            {

                var IllustrationType = myStory.Illustrations;

                IllustrationType = IllustrationType.Trim();

                if (IllustrationType.EndsWith(","))
                {
                    IllustrationType = IllustrationType.Remove(IllustrationType.Length - 1, 1);
                }

                string[] Illustrationchosen = IllustrationType.Split(',');
                //model = new DropdownModel();

                //model = myGetLookups.GeLookupAnimal();


                for (int i = 0; i < Illustrationchosen.Length; i++)
                {
                    var x = Illustrationchosen[i];


                    foreach (SelectListItem s in model.items)
                    {
                        if (s.Value == x)
                        {
                            s.Selected = true;
                        }
                    }


                }

                //ViewData["animalTypeData"] = model.items;

                myStory.IllustrationsCombo = model;

            }
            myStory.IllustrationsCombo = model;

            //ViewData["IllustrationsData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(2);
            myStory.ReadersCombo = model;
            //ViewData["ReadersData"] = model.items;
            //model = myGetLookups.GeLookupCatUsers(3);
            model = myGetLookups.GeLookupCatUsers(3);

            if (mode == "edit")
            {

                var MusicType = myStory.Music;

                MusicType = MusicType.Trim();

                if (MusicType.EndsWith(","))
                {
                    MusicType = MusicType.Remove(MusicType.Length - 1, 1);
                }

                string[] Musicchosen = MusicType.Split(',');
                //model = new DropdownModel();

                //model = myGetLookups.GeLookupAnimal();
                //model = myGetLookups.GeLookupCatUsers(3);

                for (int i = 0; i < Musicchosen.Length; i++)
                {
                    var x = Musicchosen[i];


                    foreach (SelectListItem s in model.items)
                    {
                        if (s.Value == x)
                        {
                            s.Selected = true;
                        }
                    }


                }

                //ViewData["animalTypeData"] = model.items;



                myStory.MusicCombo = model;
            }

            myStory.MusicCombo = model;
            //ViewData["MusicData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(4);
            if (mode == "edit")
            {

                myStory.DanceCombo = model;

                var DanceType = myStory.Dance;

                DanceType = DanceType.Trim();

                if (DanceType.EndsWith(","))
                {
                    DanceType = DanceType.Remove(DanceType.Length - 1, 1);
                }

                string[] Dancechosen = DanceType.Split(',');
                //model = new DropdownModel();

                //model = myGetLookups.GeLookupAnimal();
                //model = myGetLookups.GeLookupCatUsers(1);

                for (int i = 0; i < Dancechosen.Length; i++)
                {
                    var x = Dancechosen[i];


                    foreach (SelectListItem s in model.items)
                    {
                        if (s.Value == x)
                        {
                            s.Selected = true;
                        }
                    }


                }
            }
            //ViewData["animalTypeData"] = model.items;

            myStory.DanceCombo = model;



            //ViewData["DanceData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(5);
            myStory.AdminCombo = model;
            //ViewData["AdminData"] = model.items;

            model = myGetLookups.GeLookupJakataMaster();
            ViewData["jakataMasterData"] = model.items;

            model = myGetLookups.GeLookupStorySource();
            ViewData["storySourceData"] = model.items;

            model = myGetLookups.GeLookupJakataMaster();


            Story modelStory = new Story();
            modelStory = myGetLookups.GetSpecificStory(row, "jakataID");

            var ID1 = modelStory.ID.ToString();
            ViewData["id"] = ID1;

            var JakataID = modelStory.JakataID;
            var JakataIDString = modelStory.JakataID.ToString();
            ViewData["JakataID"] = JakataIDString;

            var title = JakataID.ToString();

            foreach (SelectListItem s in model.items)
            {
                if (s.Value == title)
                {
                    s.Selected = true;
                    myStory.TitleString = s.Text;
                }
            }

            GetLookups myYouTubeGetLookups = new GetLookups();
            model = myYouTubeGetLookups.GetYouTube(JakataID, userID);
            //ViewData["youTubeData"] = model.items;
            myStory.youTubeCombo = model;





            ViewData["jakataMasterData"] = model.items;


            //myStory.Posted = "0";



            return View(myStory);
        }

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = @"<img src='cid:" + res.ContentId + @"'/>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        public void UploadPictureFile(FormCollection form)
        {
            try
            {
                System.Web.HttpPostedFileBase httpPostedFileBase1 = base.Request.Files["FileData"];
                string filename1check = httpPostedFileBase1.FileName;
                string titleCheck = filename1check.Substring(0, filename1check.Length - 4);
            }
            catch
            {

                //return RedirectToAction("..\\Home");
                return;
            }

            System.Web.HttpPostedFileBase httpPostedFileBase = base.Request.Files["FileData"];
            string userID = base.Request.Form["idPhoto"];
            string comments = base.Request.Form["comments"];
            string url = base.Request.Form["url"];
            string filename1 = httpPostedFileBase.FileName;
            string picturename = base.Request.Form["picturename"];
            string title = "";

            if (picturename.Length > 0)
            {
                title = picturename;
            }
            else
            {
                title = filename1.Substring(0, filename1.Length - 4);

            }


            string text2 = base.Server.MapPath("~/images/" + System.IO.Path.GetFileName(httpPostedFileBase.FileName));
            string value = string.Empty;
            string text3 = System.IO.Path.GetExtension(httpPostedFileBase.FileName);
            text3 = text3.ToLower();
            GetStories myGetStories = new GetStories();

            ViewData["filename1"] = filename1;
            ViewData["title1"] = title;
            ViewData["url"] = url;


            if (userID == "" || userID == null)
            {
                //return RedirectToAction("..\\Home");
                return;

            }

            var email = myGetStories.GetMothersEmail(Convert.ToInt16(userID));


            if (text3 == ".jpg" || text3 == ".gif" || text3 == ".png" || text3 == ".mp3" || text3 == ".mp4")
            {
                if (httpPostedFileBase.ContentLength > 0)
                {
                    //string filename = base.Server.MapPath("/images/upload/" + text + text3);
                    //string filename = base.Server.MapPath("/images/" + filename1);
                    string filename = "C:\\Users\\Richard\\Google Drive\\WebSites\\Twoboots\\images\\" + filename1;
                    httpPostedFileBase.SaveAs(filename);

                    DynamicParameters dynamicParameters = new DynamicParameters();


                    dynamicParameters.Add("@Comments", comments, null, null, null);
                    dynamicParameters.Add("@fileName", filename1, null, null, null);
                    dynamicParameters.Add("@title", title, null, null, null);
                    dynamicParameters.Add("@url", url, null, null, null);

                    dynamicParameters.Add("@userID", System.Convert.ToInt16(userID), null, null, null);
                    ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LocalStory"];
                    string connectionString = connectionStringSettings.ConnectionString;

                    using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        const string storedProcedure = "dbo.InsertPicture";
                        var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                        //}

                        int lastRecord = 0;



                        foreach (ReceipeTotalModel v in values)
                        {
                            lastRecord = v.totalReceipesInt;
                        }


                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress("JatakaFun@gmail.com");
                            mail.To.Add(email);
                            mail.Subject = "Thank you for your photo";
                            //mail.Body = "<h2>Thanks for uploading your file " + filename1 + " </h2>";
                            string connect =ConfigurationManager.ConnectionStrings["LocalURI"].ConnectionString;

                            mail.Body = "<h1>"+connect+"Home/DishUpdate/?id=" + lastRecord + "</h1><h2>Thanks for uploading your file " + filename1 + " </h2>";
                            //mail.Body = "<h1>https://localhost:44385/Home/DishUpdate/?id=" + lastRecord + "</h1><h2>Thanks for uploading your file " + filename1 + " </h2>";

                            //mail.AlternateViews.Add(getEmbeddedImage(filename));
                            mail.IsBodyHtml = true;
                            //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                            {
                                smtp.UseDefaultCredentials = false;
                                smtp.EnableSsl = true;
                                smtp.Credentials = new NetworkCredential("JatakaFun@gmail.com", "3Monkeys!");
                                smtp.Send(mail);
                            }
                        }
                    }


                    //return View();
                    //return Redirect("..\\Home");
                    //return RedirectToAction("..\\Home");
                    //return RedirectToAction("Home", "Index");
                }
                else
                {

                    //return RedirectToAction("..\\Home");

                }

            }

        }

        private AlternateView getEmbeddedmp3(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = @"<embed src='cid:" + res.ContentId + @"'/>";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }


        public void UploadBackgroundFile(FormCollection form)
        {
            try
            {
                System.Web.HttpPostedFileBase httpPostedFileBase1 = base.Request.Files["FileDataBackground"];
                string filename1check = httpPostedFileBase1.FileName;
                string titleCheck = filename1check.Substring(0, filename1check.Length - 4);
            }
            catch
            {

                //return RedirectToAction("..\\Home");
                return;
            }

            System.Web.HttpPostedFileBase httpPostedFileBase = base.Request.Files["FileDataBackground"];
            string userID = base.Request.Form["idPhoto"];
            string filename1 = httpPostedFileBase.FileName;
            string picturename = base.Request.Form["picturename"];


            string text2 = base.Server.MapPath("~/images/" + System.IO.Path.GetFileName(httpPostedFileBase.FileName));
            string value = string.Empty;
            string text3 = System.IO.Path.GetExtension(httpPostedFileBase.FileName);
            text3 = text3.ToLower();
            GetStories myGetStories = new GetStories();




            if (userID == "" || userID == null)
            {
                //return RedirectToAction("..\\Home");
                return;

            }

            var email = myGetStories.GetMothersEmail(Convert.ToInt16(userID));


            if (text3 == ".jpg" || text3 == ".gif" || text3 == ".png" || text3 == ".mp3" || text3 == ".mp4")
            {
                if (httpPostedFileBase.ContentLength > 0)
                {
                    //string filename = base.Server.MapPath("/images/upload/" + text + text3);
                    //string filename = base.Server.MapPath("/images/" + filename1);
                    string filename = "C:\\Users\\Richard\\Google Drive\\WebSites\\Twoboots\\Content\\" + filename1;
                    httpPostedFileBase.SaveAs(filename);
                    ViewData["filenameBackground"] = filename1;

                    DynamicParameters dynamicParameters = new DynamicParameters();



                    dynamicParameters.Add("@fileName", filename1, null, null, null);
                    dynamicParameters.Add("@userID", System.Convert.ToInt16(userID), null, null, null);
                    ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LocalStory"];
                    string connectionString = connectionStringSettings.ConnectionString;

                    using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        const string storedProcedure = "dbo.InsertBackground";
                        var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
                    }

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("JatakaFun@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Thank you for your background music";
                        mail.Body = "<h2>Thanks for uploading your file " + filename1 + " </h2>";
                        mail.AlternateViews.Add(getEmbeddedmp3(filename));
                        mail.IsBodyHtml = true;
                        //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.UseDefaultCredentials = false;
                            smtp.EnableSsl = true;
                            smtp.Credentials = new NetworkCredential("JatakaFun@gmail.com", "3Monkeys!");
                            smtp.Send(mail);
                        }
                    }


                    //return View();
                    //return Redirect("..\\Home");
                    //return RedirectToAction("..\\Home");
                    //return RedirectToAction("Home", "Index");
                }
                else
                {

                    //return RedirectToAction("..\\Home");

                }

            }

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadPicture(FormCollection form)
        {

            System.Web.HttpPostedFileBase httpPostedFileBase2 = base.Request.Files["FileData"];
            string filename1check2 = httpPostedFileBase2.FileName;

            if (filename1check2 != "")
            {
                UploadPictureFile(form);

            }

            System.Web.HttpPostedFileBase httpPostedFileBase3 = base.Request.Files["FileDataBackground"];
            string filename1checkBackground = httpPostedFileBase3.FileName;

            if (filename1checkBackground != "")
            {
                UploadBackgroundFile(form);


            }



            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UploadCoupon(FormCollection form)
        {

            try
            {
                System.Web.HttpPostedFileBase httpPostedFileBase1 = base.Request.Files["FileData"];
                string filename1check = httpPostedFileBase1.FileName;
                string titleCheck = filename1check.Substring(0, filename1check.Length - 4);
            }
            catch
            {

                return RedirectToAction("..\\Home", "Coupon");
                //return;
            }

            System.Web.HttpPostedFileBase httpPostedFileBase = base.Request.Files["FileData"];
            string userID = base.Request.Form["idPhoto"];
            string dayOfWeek = base.Request.Form["idDayOfWeek"];
            if (dayOfWeek == "Please Select")
            {
                dayOfWeek = "";
            }

            string comments = base.Request.Form["comments"];
            string url = base.Request.Form["url"];
            string startDate = base.Request.Form["StartDate1"];
            string endDate = base.Request.Form["StopDate1"];
            string filename1 = httpPostedFileBase.FileName;
            string picturename = base.Request.Form["picturename"];
            string title = "";

            if (picturename.Length > 0)
            {
                title = picturename;
            }
            else
            {
                title = filename1.Substring(0, filename1.Length - 4);

            }


            string text2 = base.Server.MapPath("~/images/" + System.IO.Path.GetFileName(httpPostedFileBase.FileName));
            string value = string.Empty;
            string text3 = System.IO.Path.GetExtension(httpPostedFileBase.FileName);
            text3 = text3.ToLower();
            GetStories myGetStories = new GetStories();

            ViewData["filename1"] = filename1;
            ViewData["title1"] = title;
            ViewData["url"] = url;

            ViewData["startDate"] = startDate;
            ViewData["endDate"] = endDate;


            if (userID == "" || userID == null)
            {
                return RedirectToAction("..\\Home", "Coupon");
                //return;

            }

            var email = myGetStories.GetMothersEmail(Convert.ToInt16(userID));


            if (text3 == ".jpg" || text3 == ".gif" || text3 == ".png" || text3 == ".mp3" || text3 == ".mp4" )
            {
                if (httpPostedFileBase.ContentLength > 0)
                {
                    //string filename = base.Server.MapPath("/images/upload/" + text + text3);
                    //string filename = base.Server.MapPath("/images/" + filename1);
                    string filename = "C:\\Users\\Richard\\Google Drive\\WebSites\\Twoboots\\images\\" + filename1;
                    httpPostedFileBase.SaveAs(filename);

                    DynamicParameters dynamicParameters = new DynamicParameters();


                    dynamicParameters.Add("@Comments", comments, null, null, null);
                    dynamicParameters.Add("@fileName", filename1, null, null, null);
                    dynamicParameters.Add("@title", title, null, null, null);
                    dynamicParameters.Add("@url", url, null, null, null);
                    dynamicParameters.Add("@startDate", startDate, null, null, null);
                    dynamicParameters.Add("@endDate", endDate, null, null, null);
                    dynamicParameters.Add("@dayOfWeek", dayOfWeek, null, null, null);

                    dynamicParameters.Add("@userID", System.Convert.ToInt16(userID), null, null, null);
                    ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["LocalStory"];
                    string connectionString = connectionStringSettings.ConnectionString;


                    using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        const string storedProcedure = "dbo.InsertCoupon";
                        var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                        int lastRecord = 0;
                        
                       

                        foreach (ReceipeTotalModel v in values)
                        {
                            lastRecord = v.totalReceipesInt;
                        }


                        //}



                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress("JatakaFun@gmail.com");
                            mail.To.Add(email);
                            mail.Subject = "Thank you for your photo";

                            string connect = ConfigurationManager.ConnectionStrings["LocalURI"].ConnectionString;

                            mail.Body = "<h1>" + connect + "Home/DishUpdate/?id=" + lastRecord + "</h1><h2>Thanks for uploading your file " + filename1 + " </h2>";


                            //mail.Body = "<h1>https://localhost:44385/Home/CouponUpdate/?id=" + lastRecord + "></h1><h2>Thanks for uploading your file " + filename1 + " </h2>";
                            //mail.AlternateViews.Add(getEmbeddedImage(filename));
                            mail.IsBodyHtml = true;
                            //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                            {
                                smtp.UseDefaultCredentials = false;
                                smtp.EnableSsl = true;
                                smtp.Credentials = new NetworkCredential("JatakaFun@gmail.com", "3Monkeys!");
                                smtp.Send(mail);
                            }
                        }
                    }


                    //return View();
                    //return Redirect("..\\Home");
                    //return RedirectToAction("..\\Home");
                    //return RedirectToAction("Home", "Index");
                }
                else
                {

                    //return RedirectToAction("..\\Home");

                }

            }



            return View();
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateUser(FormCollection form)
        {
            string userID = base.Request.Form["idPhoto"];
            ViewData["userID"] = userID;

            GetStories myGetStories = new GetStories();
            var email = myGetStories.GetMothersEmail(Convert.ToInt16(userID));
            ViewData["email"] = email;
            string userName = base.Request.Form["userName"];
            //ViewData["userName"] = userName;

            MothersHelpersSpecificList myMothersHelpersSpecificList = new MothersHelpersSpecificList();
            myMothersHelpersSpecificList = myGetStories.GetMothersHelpersTypeSpecific(Convert.ToInt16(userID));



            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();

            Story myStory = new Story();
            myStory.userName = userName;

            model = myGetLookups.GetMothersHelpersType();

            for (int i = 0; i < myMothersHelpersSpecificList.mothersHelpersSpecificLists.Count; i++)
            {
                var x = myMothersHelpersSpecificList.mothersHelpersSpecificLists[i].MothersHelpersType;


                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == x)
                    {
                        s.Selected = true;
                    }
                }


            }


            ViewData["MothersHelpersTypeData"] = model.items;
            myStory.MothersHelpersTypeCombo = model;




            return View(myStory);

        }

        public ActionResult NewUser()
        {
            ViewBag.Message = "Your app description page.";
            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();
            GetStories myGetStories = new GetStories();
            MothersHelpersSpecificList myMothersHelpersSpecificList = new MothersHelpersSpecificList();
            myMothersHelpersSpecificList = myGetStories.GetMothersHelpersTypeSpecific(0);
            Story myStory = new Story();

            model = myGetLookups.GetMothersHelpersType();
            myStory.MothersHelpersTypeCombo = model;

            return View(myStory);


        }


        public ActionResult User()
        {
            ViewBag.Message = "Your app description page.";

            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();


            model = myGetLookups.GeLookupCatUsers(0);
            //model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

            ViewData["newReadersData"] = model.items;



            return View();
        }

        public ActionResult BookGenerator()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
    }
}
