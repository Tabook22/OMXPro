using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
namespace OMXPro.Controllers
{
    public class CarouselController : Controller
    {
        OmxtechDbContext db = new OmxtechDbContext();
        // GET: Carousel
        public ActionResult Index()
        {
            return View();
        }

        //site top carousle
        public ActionResult siteCarousel()
        {
            var getSitCarousel = db.tbl_articles.Where(x => x.a_loc == "3").ToList();

            return PartialView("_SiteCarousle", getSitCarousel);
        }

    }
}