using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Stories.Factory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Xml.XPath;
using Stories.Models;

namespace Jataka.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        //public ActionResult SearchAPI()
        //{


        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}

        public ActionResult Search()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Message = "Your app description page.";

            DropdownModel model = new DropdownModel();
            DropdownModel model1 = new DropdownModel();
            DropdownModel modelAnimal = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();
            model = myGetLookups.GeLookupAnimal();

            ViewData["animalTypeData"] = model.items;

            Story myStory = new Story();
            myStory.animalCombo = model;

            //modelAnimal = model;

            model = myGetLookups.GeLookupMoral();
            ViewData["moralTypeData"] = model.items;

            model = myGetLookups.GeLookupStorySource();
            ViewData["storySourceData"] = model.items;

            model = myGetLookups.GeLookupJakataMaster();
            //ViewData["jakataMasterData"] = model.items;

            DropdownModel modelUserID = new DropdownModel();
           

            modelUserID = myGetLookups.GeLookupCatUsers(2);
            
            //model.items.Add

            ViewData["newReadersData"] = modelUserID.items;

            model = myGetLookups.GetStoryCategorytName();
            ViewData["StoryCategorytNameData"] = model.items;

            ViewData["jakataMasterData"] = model1.items;



            return View(myStory);
        }

        public ActionResult Project()
        {
            ViewBag.Title = "Project";
            Story myStory = new Story();
            DropdownModel model = new DropdownModel();
            DropdownModel modelAnimal = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();
            model = myGetLookups.GeLookupCatUsers(1);
            myStory.IllustrationsCombo = model;
            //ViewData["IllustrationsData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(2);
            myStory.ReadersCombo = model;
            //ViewData["ReadersData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(3);
            myStory.MusicCombo = model;
            //ViewData["MusicData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(4);
            myStory.DanceCombo = model;
            //ViewData["DanceData"] = model.items;
            model = myGetLookups.GeLookupCatUsers(5);
            myStory.AdminCombo = model;
            //ViewData["AdminData"] = model.items;

            model = myGetLookups.GeLookupJakataMaster();
            ViewData["jakataMasterData"] = model.items;





            return View(myStory);
        }


        //[HttpPost]
        [HttpGet]
        //[AcceptVerbs(HttpVerbs.Post)]



        public ActionResult SearchResults(String searchResults, string page,int userIdPost)
        {

            Story modelStory = new Story();
            Story myStory = new Story();

            if (searchResults == "")
            {
                return View(myStory);

            }
            ViewBag.Message = "Your app description page.";


            //page = "0";



            //if (page == "0")
            //{
            //    page = "1";
            //}
            //else
            //{
            //    int pagenum = Convert.ToInt16(page) * 10;
            //    page = pagenum.ToString();
            //}

            ViewData["currentPage"] = page;

            var rows = searchResults;

            rows = searchResults.Trim();

            if (rows.EndsWith("|"))
            {
                rows = rows.Remove(rows.Length - 1, 1);
            }
            ViewData["searchResults"] = rows;

            string[] rowschosen = rows.Split('|');
            string choosen = "";

            try
            {
                choosen = rowschosen[Convert.ToInt16(page)-1];

            }
            catch (Exception ex)
            {
                choosen = rows;

            }

            //string choosen = rowschosen[Convert.ToInt16(page)];

            int total1 = rowschosen.Count();
            string total = total1.ToString();
            int pages = 0;

            try
            {
                pages = total1;
                ViewData["total"] = pages;
            }
            catch
            {
                ViewData["total"] = 0;
            }

            int row = Convert.ToInt16(choosen);

            DropdownModel model = new DropdownModel();
            GetLookups myGetLookups = new GetLookups();

            modelStory = myGetLookups.GetSpecificStory(row);

            var ID1 = modelStory.ID.ToString();
            ViewData["id"] = ID1;

            var JakataID = modelStory.JakataID;
            var JakataIDString = modelStory.JakataID.ToString();
            ViewData["JakataID"] = JakataIDString;

            var Comments = modelStory.Comments;
            var Moraltype = modelStory.MoralType;
            var Stories = modelStory.Stories;
            var StoryCategorytName = modelStory.StoryCategorytName;
            ViewData["StoryCategorytName"] = StoryCategorytName;
            var Title = modelStory.Title;

            ViewData["comments"] = Comments;
            ViewData["Stories"] = Stories;





            model = myGetLookups.GeLookupSpecificStoryDropdown();
            //DropdownModel model = new DropdownModel();
            model = myGetLookups.GeLookupAnimal();


            var AnimalType = modelStory.AnimalType;

            if (AnimalType != null)
            {

                AnimalType = AnimalType.Trim();

                if (AnimalType.EndsWith(","))
                {
                    AnimalType = AnimalType.Remove(AnimalType.Length - 1, 1);
                }

                string[] Animalchosen = AnimalType.Split(',');
                //model = new DropdownModel();

                model = myGetLookups.GeLookupAnimal();

                for (int i = 0; i < Animalchosen.Length; i++)
                {
                    var x = Animalchosen[i];


                    foreach (SelectListItem s in model.items)
                    {
                        if (s.Value == x)
                        {
                            s.Selected = true;
                        }
                    }


                }


            }





            ViewData["animalTypeData"] = model.items;

            //Story myStory = new Story();
            myStory.animalCombo = model;

            int userID = modelStory.UserID;

            

            //modelAnimal = model;
            DropdownModel modelMoral = new DropdownModel();

            modelMoral = myGetLookups.GeLookupMoral();


            var moral = Moraltype.ToString();

            foreach (SelectListItem s in modelMoral.items)
            {
                if (s.Value == moral)
                {
                    s.Selected = true;
                }
            }
            ViewData["moralTypeData"] = modelMoral.items;



            model = myGetLookups.GeLookupStorySource();
            ViewData["storySourceData"] = model.items;

            model = myGetLookups.GeLookupJakataMaster();

            var title = JakataID.ToString();

            foreach (SelectListItem s in model.items)
            {
                if (s.Value == title)
                {
                    s.Selected = true;
                }
            }


            ViewData["jakataMasterData"] = model.items;


            // titles done
            model = myGetLookups.GetStatus(1);
            ViewData["Done"] = model.items;
            myStory.done = model;

            model = myGetLookups.GetStatus(0);
            myStory.toDo = model;
            ViewData["ToDo"] = model.items;
            ViewData["myStory"] = myStory;
            myStory.Stories = (string)ViewData["Stories"];

            model = myGetLookups.GeLookupCatUsers(2);
            myStory.ReadersCombo = model;

            foreach (SelectListItem s in model.items)
            {
                if (s.Value == userID.ToString())
                {
                    s.Selected = true;
                    modelStory.UserName = s.Text;
                    if (s.Value == "0")
                    {
                        modelStory.UserName = "";
                    }
                }
            }

            ViewData["userIdPost"] = userIdPost;

            GetLookups myYouTubeGetLookups = new GetLookups();
           

            model = myYouTubeGetLookups.GetYouTube(JakataID, userIdPost);
            myStory.youTubeCombo = model;

            GetStories myGetstories = new GetStories();

            //modelStory.StoryCategorytNameString =myGetstories.GetStoryCategoryNameByID(StoryCategorytName);
            modelStory.StoryCategorytNameString = myGetLookups.GetStoryCategoryNameByID(StoryCategorytName);

            
            return View(modelStory);


        }


        //public ActionResult Test(String searchResults, string page)
        //{



        //    Story modelStory = new Story();
        //    Story myStory = new Story();

        //    if (searchResults == "")
        //    {
        //        return View(myStory);

        //    }
        //    ViewBag.Message = "Your app description page.";


        //    //page = "0";



        //    //if (page == "0")
        //    //{
        //    //    page = "1";
        //    //}
        //    //else
        //    //{
        //    //    int pagenum = Convert.ToInt16(page) * 10;
        //    //    page = pagenum.ToString();
        //    //}

        //    ViewData["currentPage"] = page;

        //    var rows = searchResults;

        //    rows = searchResults.Trim();

        //    if (rows.EndsWith("|"))
        //    {
        //        rows = rows.Remove(rows.Length - 1, 1);
        //    }
        //    ViewData["searchResults"] = rows;

        //    string[] rowschosen = rows.Split('|');

        //    string choosen = rowschosen[Convert.ToInt16(page)];

        //    int total1 = rowschosen.Count();
        //    string total = total1.ToString();
        //    int pages = 0;

        //    try
        //    {
        //        pages = total1;
        //        ViewData["total"] = pages;
        //    }
        //    catch
        //    {
        //        ViewData["total"] = 0;
        //    }

        //    int row = Convert.ToInt16(choosen);

        //    DropdownModel model = new DropdownModel();
        //    GetLookups myGetLookups = new GetLookups();

        //    modelStory = myGetLookups.GetSpecificStory(row);

        //    var ID1 = modelStory.ID.ToString();
        //    ViewData["id"] = ID1;

        //    var JakataID = modelStory.JakataID;
        //    var JakataIDString = modelStory.JakataID.ToString();
        //    ViewData["JakataID"] = JakataIDString;

        //    var Comments = modelStory.Comments;
        //    var Moraltype = modelStory.MoralType;
        //    var Stories = modelStory.Stories;
        //    var StoryCategorytName = modelStory.StoryCategorytName;
        //    var Title = modelStory.Title;

        //    ViewData["comments"] = Comments;
        //    ViewData["Stories"] = Stories;





        //    model = myGetLookups.GeLookupSpecificStoryDropdown();
        //    //DropdownModel model = new DropdownModel();
        //    model = myGetLookups.GeLookupAnimal();


        //    var AnimalType = modelStory.AnimalType;

        //    if (AnimalType != null)
        //    {

        //        AnimalType = AnimalType.Trim();

        //        if (AnimalType.EndsWith(","))
        //        {
        //            AnimalType = AnimalType.Remove(AnimalType.Length - 1, 1);
        //        }

        //        string[] Animalchosen = AnimalType.Split(',');
        //        //model = new DropdownModel();

        //        model = myGetLookups.GeLookupAnimal();

        //        for (int i = 0; i < Animalchosen.Length; i++)
        //        {
        //            var x = Animalchosen[i];


        //            foreach (SelectListItem s in model.items)
        //            {
        //                if (s.Value == x)
        //                {
        //                    s.Selected = true;
        //                }
        //            }


        //        }


        //    }





        //    ViewData["animalTypeData"] = model.items;

        //    //Story myStory = new Story();
        //    myStory.animalCombo = model;

        //    GetLookups myYouTubeGetLookups = new GetLookups();
        //    model = myYouTubeGetLookups.GetYouTube(JakataID);
        //    //ViewData["youTubeData"] = model.items;
        //    myStory.youTubeCombo = model;




        //    //modelAnimal = model;
        //    DropdownModel modelMoral = new DropdownModel();

        //    modelMoral = myGetLookups.GeLookupMoral();


        //    var moral = Moraltype.ToString();

        //    foreach (SelectListItem s in modelMoral.items)
        //    {
        //        if (s.Value == moral)
        //        {
        //            s.Selected = true;
        //        }
        //    }
        //    ViewData["moralTypeData"] = modelMoral.items;



        //    model = myGetLookups.GeLookupStorySource();
        //    ViewData["storySourceData"] = model.items;

        //    model = myGetLookups.GeLookupJakataMaster();

        //    var title = JakataID.ToString();

        //    foreach (SelectListItem s in model.items)
        //    {
        //        if (s.Value == title)
        //        {
        //            s.Selected = true;
        //        }
        //    }


        //    ViewData["jakataMasterData"] = model.items;


        //    // titles done
        //    model = myGetLookups.GetStatus(1);
        //    ViewData["Done"] = model.items;
        //    myStory.done = model;

        //    model = myGetLookups.GetStatus(0);
        //    myStory.toDo = model;
        //    ViewData["ToDo"] = model.items;
        //    ViewData["myStory"] = myStory;



        //    //return View(myStory);
        //    //RedirectToAction("Create", "SearchResults");

        //    //Response.AddHeader("Refresh", "5");
        //    ModelState.Clear();
        //    ModelState.Remove("Stories.Models.Story");

        //    myStory.Stories = Stories;
        //    return View();


        //}


    }



}