using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using FileUploading.Models; // If we do not have this then it is

// List<Models.FileModel> files = new List<Models.FileModel>();

using System.Collections.Generic; // Helps with lists

using System.IO; // Required for reading and writing IO (Input / Output).
using System.Web.Mvc;
using u21448567_HW03.Models;

namespace u21448567_HW03.Controllers
{
    public class FileController : Controller
    {
        public ActionResult Index()
        {
            //Fetch all files in the Folder (Directory).

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));

            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files) //INSIDE HOME
        {
            // Verify that the user selected a file
            // Not null and has a length

            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/Media/Documents folder

                var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }
            // redirect back to the index action to show the form once again

            return RedirectToAction("Index");
        }

        public FileResult DownloadFile(string fileName) // Why fileName and not FileName????
                                                        // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}