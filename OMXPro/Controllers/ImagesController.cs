using OMXPro.Models;
using OMXPro.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OmxTechNet.Controllers
{
    public class ImagesController : Controller
    {

        private OmxtechDbContext db = new OmxtechDbContext();
        // GET: Images
        public ActionResult Index()
        {
            var getImgLst = db.tbl_images.Select(x => new ImageViewModel
            {
                imgid = x.imgid,
                imgurl_lg = x.imgurl_lg,
                imgurl_th = x.imgurl_th
            }).ToList();
            return View(getImgLst);
        }

        public ActionResult Create()
        {
            return View();
        }


        //TODO:Reduce the image sizes
        private void GenerateThumbnails(double scaleFactor, Stream sourcePath, string targetPath)
        {
            using (var image = Image.FromStream(sourcePath))
            {
                var newWidth = (int)(image.Width * scaleFactor);
                var newHeight = (int)(image.Height * scaleFactor);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }


        //TODO: upload images to database and into site upload directory
        [HttpPost]
        public ActionResult BatchUpload()
        {
            bool isSavedSuccessfully = true;
            int count = 0;
            string msg = "";
            string fileName = "";
            string fileExtension = "";
            string filePath = "";
            string fileNewName = "";

            //  here is obtain strong  
            //int albumId = string.IsNullOrEmpty(Request.Params["hidAlbumId"])  
            //    0 : int.Parse(Request.Params["hidAlbumId"]);

            tbl_image ItmImg = new tbl_image();
            try
            {
                string directoryPath = Server.MapPath("~/uploads/images");
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);

                foreach (string f in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[f];

                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = file.FileName;
                        fileExtension = Path.GetExtension(fileName);
                        fileNewName = Guid.NewGuid().ToString() + fileExtension;
                        filePath = Path.Combine(directoryPath, fileNewName);
                        file.SaveAs(filePath);

                        Stream strm = file.InputStream;
                        string path_Thumb = System.IO.Path.Combine(Server.MapPath("~/uploads/Thumbs"), fileNewName);
                        ItmImg.imgurl_lg = "/uploads/Images/" + fileNewName; //path to large images
                        ItmImg.imgurl_th = "/uploads/Thumbs/" + fileNewName; // path to thumbnail images
                        GenerateThumbnails(0.5, strm, path_Thumb); //here reducing the image by 50%

                        db.tbl_images.Add(ItmImg);
                        db.SaveChanges();
                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                isSavedSuccessfully = false;
            }

            return Json(new
            {
                Result = isSavedSuccessfully,
                Count = count,
                Message = msg
            });
        }

        public JsonResult getItmImages()
        {
            var getImgLst = db.tbl_images.Select(x => x.imgurl_lg);
            return Json(new { getImgLst }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteImage(int id)
        {
            string getImgUrl_lg = Server.MapPath(db.tbl_images.Where(x => x.imgid.Equals(id)).FirstOrDefault().imgurl_lg); //get large image
            string getImgUrl_th = Server.MapPath(db.tbl_images.Where(x => x.imgid.Equals(id)).FirstOrDefault().imgurl_th); //get thumbnail image
            tbl_image imgItm = db.tbl_images.Find(id);
            db.tbl_images.Remove(imgItm);
            db.SaveChanges();

            //delete image from upload folder
            FileInfo file1 = new FileInfo(getImgUrl_lg);
            FileInfo file2 = new FileInfo(getImgUrl_th);
            file1.Delete();
            file2.Delete();
            return RedirectToAction("Index");
        }

        //TODO: Adding Site Logo
        public ActionResult SiteLogo()
        {
            ViewBag.CurrentPage = 1;
            ViewBag.LastPage =Math.Ceiling(Convert.ToDouble(db.tbl_images.ToList().Count())/ 5); //here we divid the total pages by page size then we used math.celling method to get the upper value (e.g 11/5=2.2, the upper value here is 3 so with math.celling we get 11/5=3)
            return PartialView(db.tbl_images.Take(5));
        }

        [HttpPost]
        public ActionResult SiteLogo(int CurrentPage, int LastPage)
        {
            ViewBag.CurrentPage = CurrentPage; //to update the viewbage with the new values
            ViewBag.LastPage = LastPage;
            return PartialView("_imageList",db.tbl_images.OrderBy(x => x.imgid).Skip((CurrentPage - 1) * 5).Take(5));
        }
        //TODO: Get Image List
        public ActionResult imageList()
        {
            ViewBag.CurrentPage = 1;
            return PartialView("imageList",db.tbl_images.Take(5));
        }
        [HttpPost]
        public ActionResult imageLis(int CurrentPage)
        {
            ViewBag.CurrentPage = CurrentPage;
            return PartialView("imageList", db.tbl_images.OrderBy(x=>x.imgid).Skip((CurrentPage - 1) * 5).Take(5));
        }

        //TODO:Display Site Logo
        public ActionResult DisplaySiteLogoImg()
        {
            var getsitelog = db.tbl_images.Where(x => x.imgrole == "SiteLogo").FirstOrDefault();
            return PartialView("_siteimg",getsitelog);
        }
        //TODO:Save Site Logo
        //TODO:Display Site Logo
        [HttpPost]
        public JsonResult SaveSiteLogoImg(string imgurl)
        {
            tbl_image myimg =db.tbl_images.Where(x=>x.imgrole =="SiteLogo").FirstOrDefault();
            myimg.imgurl_lg = imgurl;
            db.SaveChanges();

            return Json("الحمد لله رب العالمين",JsonRequestBehavior.AllowGet);
        }

    }
}