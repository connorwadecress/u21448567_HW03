using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21448567_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()  //INSIDE FileUpload
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase files)
        //{
        //    // Verify that the user selected a file
        //    // Not null and has a length

        //    if (files != null && files.ContentLength > 0)
        //    {
        //        // extract only the filename

        //        var fileName = Path.GetFileName(files.FileName);

        //        // store the file inside ~/App_Data/uploads folder

        //        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

        //        // The chosen default path for saving

        //        files.SaveAs(path);
        //    }
        //    // redirect back to the index action to show the form once again

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string chooseFileType)
        {
            if (files == null || chooseFileType == null)
            {
                ViewBag.Message = "Please make sure that file and file type is selected";
            }
            else if (chooseFileType == "image")
            {
                // Upload  image to the image folder               
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Images/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if (chooseFileType == "video")
            {
                // Upload video the vidoes folder
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Videos/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;
            }
            else if (chooseFileType == "document")
            {
                // Upload document to the documents folder
                string name = Path.GetFileName(files.FileName);
                string path = "~/Media/Documents/" + name;
                files.SaveAs(Server.MapPath(path));
                ViewBag.Message = path;

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}