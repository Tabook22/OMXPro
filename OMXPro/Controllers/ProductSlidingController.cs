using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
namespace OMXPro.Controllers
{
    public class ProductSlidingController : Controller
    {
        OmxtechDbContext db = new OmxtechDbContext();
        // GET: ProductSliding
        public ActionResult Index()
        {
            return View();
        }

        //product sliding
        public ActionResult productSliding()
        {
            var getProducts=(from a in db.tbl_articles
                            where a.a_loc =="9"
                            select a).ToList();

            return PartialView("_ProductSliding", getProducts);
        }
    }
}