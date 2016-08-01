using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
namespace OMXPro.Controllers
{
    public class ProductListController : Controller
    {
        OmxtechDbContext db = new OmxtechDbContext();
        // GET: ProductList
        public ActionResult Index()
        {
            return View();
        }

        //product list top it shows the products in the top of product list category
        public ActionResult proLstTop()
        {
            var getProLstTop = (from a in db.tbl_articles
                                where a.a_loc == "7"
                                orderby a.a_order ascending
                                select a).ToList();

            return PartialView("_productList_Top",getProLstTop); 
        }

        //product list bottom it shows the products in the bottom of product list category
        public ActionResult proLstBottom()
        {
            var getProLstBottom = (from a in db.tbl_articles
                                where a.a_loc == "8"
                                orderby a.a_order ascending
                                select a).ToList();

            return PartialView("_productList_Bottom", getProLstBottom);
        }
    }
}