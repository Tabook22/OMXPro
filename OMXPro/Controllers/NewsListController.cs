using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
namespace OMXPro.Controllers
{
    public class NewsListController : Controller
    {
        OmxtechDbContext db = new OmxtechDbContext();
        // GET: NewsList
        public ActionResult Index()
        {
            return View();
        }

        //News list 
        public ActionResult siteNewsLst()
        {
            var getNewsLst = (from a in db.tbl_articles
                                where a.a_loc == "10"
                                orderby a.a_order ascending
                                select a).ToList();

            return PartialView("_NewsList", getNewsLst);
        }

        //News Sliding 
        public ActionResult siteNewsSliding()
        {
            var getNewsSliding = (from a in db.tbl_articles
                              where a.a_loc == "11"
                              orderby a.a_order ascending
                              select a).ToList();

            return PartialView("_NewsSliding", getNewsSliding);
        }
    }
}