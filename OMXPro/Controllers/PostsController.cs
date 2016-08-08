using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Globalization;
using System.Data.Entity;
using OMXPro.Models;


namespace OMXPro.Controllers
{

    public class PostsController : Controller
    {
        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: Posts
        public ActionResult Index()
        {
            var artLst = db.tbl_posts.OrderBy(x => x.post_title).ToList();
            return View(artLst);
        }

        public ActionResult Create()
        {
            return View();
        }

        //TODO: Edit Posts
        public ActionResult Edit(int id)
        {
            var editPost = db.tbl_posts.Where(x => x.Id.Equals(id)).FirstOrDefault();
            return View(editPost);
        }

        [HttpPost]
        [ValidateInput(false)] //this is used to prevent A potentially dangerous Request.Form value was detected from the client
        public ActionResult Edit(tbl_post post)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy h:mm");
            CultureInfo us = new CultureInfo("en-US");
            CultureInfo sa = new CultureInfo("ar-SA");
            string text = date;
            string format = "dd/MM/yyyy h:mm";
            var enDate = DateTime.ParseExact(text, format, us);
            //    var arDate= DateTime.ParseExact(text, format, sa);


            //var postDate= DateTime.ParseExact(date, "dd/MM/yyyy",
            //                       new CultureInfo("en-US"));
            //var postDate = date.Date;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("MMMM");
            if (ModelState.IsValid)
            {
                try
                {
                    tbl_post upost = new tbl_post();
                    upost = db.tbl_posts.Find(post.Id);
                    upost.post_title = post.post_title;
                    upost.post_date = enDate;
                    upost.post_content = post.post_content;
                    upost.post_excerpt = post.post_excerpt;
                    upost.post_img = post.post_img;
                    upost.post_status = post.post_status;

                    db.Entry(upost).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) // catches all exceptions
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("", "Error");
            return View();
        }

        //TODO: Add New Posts
        [HttpPost]
        [ValidateInput(false)] //this is used to prevent A potentially dangerous Request.Form value was detected from the client
        public ActionResult Create(tbl_post post)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy h:mm");
            CultureInfo us = new CultureInfo("en-US");
            CultureInfo sa = new CultureInfo("ar-SA");
            string text = date;
            string format = "dd/MM/yyyy h:mm";
            var enDate = DateTime.ParseExact(text, format, us);
            //    var arDate= DateTime.ParseExact(text, format, sa);


            //var postDate= DateTime.ParseExact(date, "dd/MM/yyyy",
            //                       new CultureInfo("en-US"));
            //var postDate = date.Date;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.ToString("MMMM");
            if (ModelState.IsValid)
            {
                try
                {
                    post.post_date = enDate;
                    post.year = year;
                    post.month = month;
                    post.post_lang = "En";
                    db.tbl_posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) // catches all exceptions
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError("", "Error");
            return View(post);
        }

        //TODO: Delete Selected Postes a group delete which used checkbox
        [HttpPost]
        public ActionResult Index(string[] DeleteIds)
        {
            List<tbl_post> objPosts = new List<tbl_post>();
            int[] id = null;
            if (DeleteIds != null)
            {
                id = new int[DeleteIds.Length];
                int j = 0;
                foreach (string i in DeleteIds)
                {
                    int.TryParse(i, out id[j++]);
                }
            }
            if (id != null && id.Length > 0)
            {
                List<tbl_post> selectedIds = new List<tbl_post>();
                using (OmxtechDbContext db = new OmxtechDbContext())
                {
                    selectedIds = db.tbl_posts.Where(a => id.Contains(a.Id)).ToList();
                    foreach (var i in selectedIds)
                    {
                        db.tbl_posts.Remove(i);
                    }
                    db.SaveChanges();
                    objPosts = db.tbl_posts.ToList();
                }
                ViewBag.Success = "Selected Records are Deleted Successfully";
            }
            return View(objPosts);
        }

        //TODO: Delete selected Single post 
        public ActionResult Delete(int id)
        {
            tbl_post post = db.tbl_posts.Where(x => x.Id.Equals(id)).FirstOrDefault();
            db.tbl_posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}