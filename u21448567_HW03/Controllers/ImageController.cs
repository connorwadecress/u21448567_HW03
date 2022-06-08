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
    public class ImageController : Controller
    {
        //// GET: Image
        //public ActionResult Index()
        //{
        //    //Fetch all files in the Folder (Directory).

        //    string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Media/Images"));

        //    //Copy File names to Model collection.
        //    //The return below returns to the list here.

        //    List<FileModel> files = new List<FileModel>();

        //    foreach (string filePath in filePaths)
        //    {
        //        files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
        //    }
        //    return View(files);
        //}

        //public FileResult DownloadFile(string fileName) // Why fileName and not FileName????
        //                                                // Because of using.
        //{
        //    //Build the File Path.

        //    string path = Server.MapPath("~/App_Data/Media/Images") + fileName;

        //    //Read the File data into Byte Array.
        //    //Use a byte array becasue of octet-stream.

        //    byte[] bytes = System.IO.File.ReadAllBytes(path);

        //    //Send the File to Download.

        //    //The OCTET-STREAM format is used for file attachments on the Web with an
        //    //unknown file type. These .octet-stream files are arbitrary binary data
        //    //files that may be in any multimedia format.

        //    return File(bytes, "application/octet-stream", fileName);
        //}

        //public ActionResult DeleteFile(string fileName)
        //{
        //    //Delete requires reading the files and then the allocation of a file path.
        //    //The file is then deleted based on the identified file path.

        //    string path = Server.MapPath("~/App_Data/Media/Images") + fileName;
        //    byte[] bytes = System.IO.File.ReadAllBytes(path);

        //    System.IO.File.Delete(path);

        //    return RedirectToAction("Index");
        //}

        // GET: Images
        public ActionResult Index()
        {

            // Get Images from the files folder 
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Images"));

            List<FileModel> fileModels = new List<FileModel>();
            // Make list of Images to show in the view 
            for (int i = 0; i < files.Length; i++)
            {
                FileModel file = new FileModel();
                // Get the full path of the image
                file.FileName = Path.GetFileName(files[i]);
                fileModels.Add(file);
            }
            return View(fileModels);
        }

        //public ActionResult Download(string name)
        //{
        //    // Get the file path
        //    string fullName = Server.MapPath("~/Media/Images/" + name);

        //    byte[] fileBytes = GetFile(fullName);
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name);
        //}

        //// Method to get the file and return as a type o
        //byte[] GetFile(string s)
        //{
        //    System.IO.FileStream fs = System.IO.File.OpenRead(s);
        //    byte[] data = new byte[fs.Length];
        //    int br = fs.Read(data, 0, data.Length);
        //    if (br != fs.Length)
        //        throw new System.IO.IOException(s);
        //    return data;
        //}

        public FileResult DownloadFile(string fileName) // Why fileName and not FileName????
                                                        // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Images/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }


        //// GET: Files/Delete/5
        //public ActionResult Delete(string name)
        //{
        //    string fullPath = Request.MapPath("~/Media/Images/" + name);
        //    if (System.IO.File.Exists(fullPath))
        //    {
        //        System.IO.File.Delete(fullPath);
        //    }
        //    return RedirectToAction("Index");
        //}

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Images/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }


    }
}