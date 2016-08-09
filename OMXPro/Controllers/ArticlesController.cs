using OMXPro.Models;
using OMXPro.ViewModels;
using OMXPro.ViewModelss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace OMXPro.Controllers
{
    public class ArticlesController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: Admin/Articles
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(FormCollection collection)
        {
            ViewBag.content = collection["editor1"];
            return View();
        }

        //Get: here we are going to display a list of articles
        public ActionResult ArticleSettings()
        {
            // this is used to fill the dropdownlist
            var mydata = from se in db.tbl_sitesections
                         select new { se.secId, se.sec_title };
            SelectList mylist = new SelectList(mydata, "secId", "sec_title");
            ViewBag.mysections = mylist;

            // here i want to return the list of articles sorted by date
            //var getArtLst = (from art in db.tbl_articles
            //                 orderby art.a_date descending
            //                 select art).ToList();
            ////ViewBag.sections = new SelectList(db.tbl_siteSections, "secId", "sec_title");
            //return View(getArtLst);

            List<tbl_article> arts = ArtData("");
            return View(arts);
        }

        //TODO:Only display the result of the search
        [HttpPost]
        public ActionResult ArticleSettings(string SearchKey)
        {
            List<tbl_article> arts = ArtData(SearchKey);          
            return View(arts);
        }

        //this function will return a list of search results, which then will be displied inside the article list
        public List<tbl_article> ArtData(string SearchKey)
        {
            List<tbl_article> objArt = new List<tbl_article>();
                var productItem = from data in db.tbl_articles
                                  where SearchKey == "" ? true : data.a_title.Contains(SearchKey)
                                  select data;
                foreach (var item in productItem)
                {
                    objArt.Add(new tbl_article
                    {
                        Id = item.Id,
                        a_date = item.a_date,
                        a_title = item.a_title,
                        a_source = item.a_source,
                        a_desc = item.a_desc,
                        a_img = item.a_img,
                        a_type = item.a_type,
                        a_mediatype = item.a_mediatype,
                        a_meidatype_link = item.a_meidatype_link,
                        a_order = item.a_order,
                        a_loc = item.a_loc,
                        a_status = item.a_status
                    });
                }
           
            return objArt;
        }
        //---------------------------------------------------------------------------------------------------------------------
        //Update Article settings

        [HttpPost]
        public ActionResult upArticleSettings(tbl_article article, FormCollection form)
        {
            int getId = Convert.ToInt32(article.Id);

            if (ModelState.IsValid)
            {
                using (db)
                {
                    tbl_article tbl_art = new tbl_article();
                    tbl_art = db.tbl_articles.Where(x => x.Id == getId).FirstOrDefault();
                    //tbl_art.a_date = DateTime.Now;
                    tbl_art.a_link = article.a_link;
                    tbl_art.a_title = article.a_title;
                    tbl_art.a_desc = article.a_desc;
                    tbl_art.a_loc = form["mysections"];
                    tbl_art.a_img = article.a_img;
                    tbl_art.a_order = article.a_order;
                    tbl_art.a_status = article.a_status;
                    db.SaveChanges();
                }

            }
            return RedirectToAction("ArticleSettings");
        }
        //---------------------------------------------------------------------------------------------------------------------
        ////Post: New Article
        //[HttpPost]
        //public ActionResult ArticleSettings(Articles article, FormCollection form)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tbl_article tbl_article = new tbl_article();
        //        tbl_article.a_date = DateTime.Now;
        //        tbl_article.a_link = article.a_link;
        //        tbl_article.a_title = article.a_title;
        //        tbl_article.a_desc = article.a_desc;
        //        tbl_article.a_loc = article.a_loc;
        //        tbl_article.a_img = article.a_img;
        //        tbl_article.a_order = article.a_order;
        //        tbl_article.a_status = article.a_status;

        //        db.tbl_articles.Add(tbl_article);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}

        //---------------------------------------------------------------------------------------------------------------------
        public ActionResult FileBrowser()
        {
            return View();
        }

        public void uploadnow(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/uploads/Images"), ImageName);
                upload.SaveAs(path);
            }

        }
        public ActionResult test()
        {
            using (db)
            {
                IEnumerable<tbl_image> my_Imgs = db.tbl_images.Where(x => x.imgfolder == "carousel");
                //var getimgs = from i in my_Imgs
                //              select i;
                return View(my_Imgs.ToList());
            }

        }
        //---------------------------------------------------------------------------------------------------------------------
        // Edit articles which used in the section inside the website
        public PartialViewResult editart(int id)
        {
            //here we want to keep the same items which were selected in the dropdownlist and show them as a selected item
            tbl_article myart = db.tbl_articles.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.mysections = new SelectList(db.tbl_sitesections, "secId", "sec_title", myart.a_loc);
            return PartialView("editart", myart);
        }

        //---------------------------------------------------------------------------------------------------------------------
        public ActionResult addart()
        {
            //TODO: the create a dropdown list of all the sections and the events
            ViewBag.SectionsName = new SelectList(db.tbl_sitesections, "secId", "sec_title");
            return View();
        }
        //---------------------------------------------------------------------------------------------------------------------
        // Post adding new article or news to the site sections
        [HttpPost]
        public ActionResult addart(tbl_article article, FormCollection form)
        {
            //int getId = Convert.ToInt32(article.Id);

            if (ModelState.IsValid)
            {
                using (db)
                {
                    tbl_article tbl_art = new tbl_article();
                    //tbl_art = db.tbl_articles.Where(x => x.Id == getId).FirstOrDefault();
                    tbl_art.a_date = DateTime.Now;
                    tbl_art.a_link = article.a_link;
                    tbl_art.a_title = article.a_title;
                    tbl_art.a_desc = article.a_desc;
                    tbl_art.a_loc = form["SectionsName"];
                    tbl_art.a_img = article.a_img;
                    tbl_art.a_order = article.a_order;
                    tbl_art.a_status = article.a_status;
                    db.tbl_articles.Add(tbl_art);
                    db.SaveChanges();
                }

            }
            return RedirectToAction("ArticleSettings");
        }
        //---------------------------------------------------------------------------------------------------------------------
        // Delete articles
        public ActionResult DeleteArticles(string[] ids)
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
                List<tbl_article> allSelected = new List<tbl_article>();
                allSelected = db.tbl_articles.Where(x => id.Contains(x.Id)).ToList();
                foreach (var i in allSelected)
                {
                    db.tbl_articles.Remove(i);

                }
                db.SaveChanges();
            }
            return RedirectToAction("ArticleSettings");
        }
        //---------------------------------------------------------------------------------------------------------------------

        public ActionResult GetPostData()
        {

            var cdm = db.tbl_posts.ToList();

            return PartialView("dataList", cdm);
        }

        [HttpPost]
        public ActionResult Search(string SearchKey)
        {
            return RedirectToAction("ArticleSettings");
        }
        //public ActionResult GetPostData(int page = 1, string sort = "post_title", string sortdir = "DESC")
        //{
        //    PostDataModel cdm = new PostDataModel();
        //    cdm.PageSize = 10;
        //    using (OmxtechDbContext dc = new OmxtechDbContext())
        //    {
        //        cdm.TotalRecord = dc.tbl_posts.Count();
        //        cdm.NoOfPages = (cdm.TotalRecord / cdm.PageSize) + ((cdm.TotalRecord % cdm.PageSize) > 0 ? 1 : 0);
        //        cdm.mPost = dc.tbl_posts.OrderBy(x => x.post_title).Skip((page - 1) * cdm.PageSize).Take(cdm.PageSize).ToList();
        //    }
        //    return PartialView("dataList", cdm);
        //}
    }
}