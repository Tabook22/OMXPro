using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
using OMXPro.Models;

namespace OMXPro.Controllers
{
    public class SectionsController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: Sections
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        //Post: Site Sections
        [HttpPost]
        public ActionResult Create(tbl_siteSection sitsc, FormCollection form)
        {
            using (db)
            {
                if (ModelState.IsValid)
                {
                    tbl_siteSection secst = new tbl_siteSection();
                    secst.sec_title = sitsc.sec_title;
                    secst.sec_desc = sitsc.sec_desc;
                    secst.sec_status = sitsc.sec_status;
                    db.tbl_sitesections.Add(secst);
                    db.SaveChanges();
                }
                //ModelState.Clear();
                return RedirectToAction("Sections");
            }

        }

        public ActionResult Sections()
        {
            List<tbl_siteSection> mysec = new List<tbl_siteSection>();
            ViewBag.mysections = new SelectList(db.tbl_sitesections, "secId", "sec_title");

            mysec = db.tbl_sitesections.ToList();
            return View(mysec);


        }
        //Get: Section list
        public ActionResult SecList()
        {
            using (db)
            {
                int sct = db.tbl_sitesections.OrderBy(x => x.secId).Count();
                var getSecLst = db.tbl_sitesections.ToList();
                return View(getSecLst);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public ActionResult secEdit(string id)
        {

            int sid = Convert.ToInt32(id);

            int mysec = db.tbl_sitesections.Where(x => x.secId == sid).Count();
            if (mysec != null)
            {
                tbl_siteSection mysections = db.tbl_sitesections.Where(x => x.secId == sid).FirstOrDefault();
                return Json(mysections, JsonRequestBehavior.AllowGet);
            }
            return Json("No value found", JsonRequestBehavior.AllowGet);

        }
    }
}