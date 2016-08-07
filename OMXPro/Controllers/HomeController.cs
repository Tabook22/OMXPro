using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
using OMXPro.ViewModels;
namespace OMXPro.Controllers
{
    public class HomeController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        public ActionResult Index_Draft()
        {
            return View();
        }
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

        //TODO:Add Site Logo
        public ActionResult siteLogo()
        {

            //get site logo
            var getsitelogo = (from a in db.tbl_images
                               where a.imgrole == "SiteLogo"
                               select a).FirstOrDefault();

            return PartialView("Header", getsitelogo);
        }

        //TODO:Get Socials
        //TODO:Add Site Logo
        public ActionResult siteSocials()
        {

            //get site Socials
            var getsitesocials = (from a in db.socials
                               select a).ToList();

            return PartialView("_Socials", getsitesocials);
        }
    }
}