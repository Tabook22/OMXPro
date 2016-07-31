using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMXPro.Models;
using OMXPro.Models;

namespace OmxTechNet.Controllers
{
    public class SiteSettingsController : Controller
    {
        private OmxtechDbContext db=new OmxtechDbContext();
        // GET: SiteSettings
        public ActionResult Index()
        {
            return View();
        }

        //TODO:Display the Contactus list page
        public ActionResult ContactUsIndex()
        {
            return View();
        }

        //TODO:Contact us partial view which contains all the contact us messages
        public ActionResult ContactUsList()
        {
            IEnumerable<tbl_contact> cLst = new List<tbl_contact>();
            cLst = db.tbl_contacts.OrderByDescending(x => x.GData).ToList();
            return View(cLst);
        }

        public JsonResult findSocials(int id)
        {
            var GetSocial = db.socials.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return Json(GetSocial, JsonRequestBehavior.AllowGet);
        }
        public ActionResult addSocialMedia()
        {


            ViewBag.Socials = db.socials.OrderBy(x => x.Order).ToList();

            return View();
        }
        public ActionResult addSlMedia(string Name, string Link, int? Order, string Img)
        {
            Social socials = new Social();
            //try
            //{               
            socials.Name = Name;
            socials.Link = Link;
            socials.Order = Convert.ToInt32(Order);
            socials.img = Img;
            db.socials.Add(socials);
            db.SaveChanges();

            string strTable = "";
            strTable = strTable + "<table class=" + "table table-condense" + " id=" + "nasser" + "><thead><tr><th></th><th>Title</th>";
            strTable = strTable + "<th>الرابط</th><th>الصورة</th><th>Order</th><th></th></tr></thead><tbody>";

            var Socials = from s in db.socials
                          orderby s.Order
                          select s;
            foreach (var item in Socials)
            {
                strTable = strTable + "<tr>";
                strTable = strTable + "<td>" + " <input type=" + "checkbox" + " value=" + item.Id + " name=" + "ids" + "/>" + "</td>";
                strTable = strTable + "<td>" + item.Name + "</td>";
                strTable = strTable + "<td>" + item.Link + "</td>";
                strTable = strTable + "<td>" + item.Order + "</td>";
                strTable = strTable + "<td>" + "<img style=" + "width:50px;" + " src =" + item.img + " />" + "</td>";
                strTable = strTable + "<td>" + "<a" + " href=" + "#" + " id ="+"btnSlectItem"+" class="+"sedit" + " data-itemid=" + item.Id + ">تعديل</a></d></td>";
                strTable = strTable + "</tr>";
            }
            strTable = strTable + "</tbody></table>";
            return Json(strTable, JsonRequestBehavior.AllowGet);
        }

        //Update Social icons in the firstpage
        [HttpPost]
        public JsonResult editSocials(string Name, string Link, int? Order, string Img, int id)
        {
            Social editSo = new Social();
            editSo = db.socials.Where(x => x.Id == id).SingleOrDefault();
            editSo.Name = Name;
            editSo.Link = Link;
            editSo.Order = Order;
            editSo.img = Img;

            db.SaveChanges();

            string strTable = "";
            strTable = strTable + "<table class=" + "table table-condense" + " id=" + "nasser" + "><thead><tr><th></th><th>العنوان</th>";
            strTable = strTable + "<th>Url</th><th>Image</th><th>Order</th><th></th></tr></thead><tbody>";

            var Socials = from s in db.socials
                          orderby s.Order
                          select s;
            foreach (var item in Socials)
            {
                strTable = strTable + "<tr>";
                strTable = strTable + "<td>" + " <input type=" + "checkbox" + " value=" + item.Id + " name=" + "ids" + "/>" + "</td>";
                strTable = strTable + "<td>" + item.Name + "</td>";
                strTable = strTable + "<td>" + item.Link + "</td>";
                strTable = strTable + "<td>" + item.Order + "</td>";
                strTable = strTable + "<td>" + "<img style=" + "width:50px;" + " src =" + item.img + " />" + "</td>";
                strTable = strTable + "<td>" + "<a" +" href="+"#"+ " id =" + "btnSlectItem" + " class=" + "sedit" + " data-itemid=" + item.Id + ">Edit</a></d></td>"; 
                strTable = strTable + "</tr>";
            }
            strTable = strTable + "</tbody></table>";
            return Json(strTable, JsonRequestBehavior.AllowGet);
        }
        public ActionResult deleteSocial(int id)
        {
            Social socials = new Social();
            socials = db.socials.Where(x => x.Id == id).SingleOrDefault();

            db.socials.Remove(socials);
            db.SaveChanges();

            return RedirectToAction("addSocialMedia");
        }
        //Delete selected Socials
        public ActionResult DelSelSocials(string[] ids)
        {
            //Delete Selected
            int[] id = null;
            if (ids != null)
            {
                id = new int[ids.Length];
                int j = 0;
                foreach (string i in ids)
                {
                    int.TryParse(i, out id[j++]);

                }
            }
            if (id != null && id.Length > 0)
            {
                List<Social> allSelected = new List<Social>();
                allSelected = db.socials .Where(x => id.Contains(x.Id)).ToList();
                foreach (var i in allSelected)
                {
                    db.socials.Remove(i);

                }
                db.SaveChanges();
            }
            return RedirectToAction("addSocialMedial");
        }

        //edit socials: this code used to display the data of the selecte row in the textfields
        public JsonResult showEditData(int id)
        {
            //var viewModel = new SiteSections();
            var mysec = db.socials.Where(x => x.Id == id).FirstOrDefault();
            //var mySoc = from s in db.Social
            //           where s.Id == id
            //          select s;
            //ViewBag.mysections = new SelectList(db.tbl_MainSections, "id", "secdesc", mysec.secId);
            return Json(mysec, JsonRequestBehavior.AllowGet);
            // return PartialView("addSocialMedia", mysec);

        }
        public JsonResult DelSocials(int ID)
        {
            // delete the record from ID and return true else false
            Social delSo = new Social();
            delSo = db.socials.Where(x => x.Id == ID).SingleOrDefault();
            db.socials.Remove(delSo);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }

}
