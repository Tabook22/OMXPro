using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMXPro.Controllers
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

        //This is header partial view
        public ActionResult Header()
        {
           
            return PartialView();
        }

        //Carousel 
        public ActionResult Carousel()
        {
            return PartialView();
        }

        //Product List
        public ActionResult ProductList()
        {
            return PartialView();
        }

        //Product Sliding
        public ActionResult ProductSliding()
        {
            return PartialView();
        }

        //News List and Events
        public ActionResult NewsList()
        {
            return PartialView();
        }

        //Footer
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}