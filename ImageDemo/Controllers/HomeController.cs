using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {

            if (file != null)
            {
                // TODO: Check if file is image

                string pic = System.IO.Path.GetFileName(file.FileName);

                // Virtualise this (VirtualMap)
                var dir = Server.MapPath("~/Images");
                var path = System.IO.Path.Combine(dir, pic);

                // Virtualise this part
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                file.SaveAs(path);

                // Copying the memory for file manipulating i.e. for storing
                // other places, or sending
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }

            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
        }
    }
}