using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cook.Models;
using Cook.API;

namespace cookin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EthnicModel model = new EthnicModel();
            EthnicRepository _ethnicRepository = new EthnicRepository();
            model = _ethnicRepository.GetModel("N");
            ViewData["ethnicData"] = model.items;

            return View();
        }

        public ActionResult Search(int ethnicCode)
        {

            var ethnic = Request.Form["ethnicCode"];
            ViewBag.Message = "Your application description page.";

            MyFavoritesModel rmodel1 = new MyFavoritesModel();
            List<MyFavoritesModel> items1 = new List<MyFavoritesModel>();
            LatestPageRepository _LatestPagePageRepository = new LatestPageRepository();
            items1 = _LatestPagePageRepository.GetModel(ethnicCode.ToString());

            ViewData["MyFavortiesData"] = items1;

            string firstOne = null;
            foreach (MyFavoritesModel s in items1)
            {
                firstOne = s.Title;
                firstOne = firstOne.Substring(0, 1);
                ViewData["firstOne"] = firstOne;
                break;
            }

            return PartialView("SearchView", items1);
            //return RedirectToAction("Index", "Home");
            //return View();
            
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