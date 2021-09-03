using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Learning_Management_System.FileUpload
{
    public class FileUpload:Controller
    {
        public string UploadImage(HttpPostedFileBase Image)
        {
            string Name = Path.GetFileName(Image.FileName); //getting name of file
            string extension = Path.GetExtension(Name);//getting extension of file
            Name = Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyyMMdhhmmss") + extension; //generating unique name of file
            string path =Path.Combine("/UploadImages" + Name);
            Image.SaveAs(Server.MapPath(path));//Save image in the specific Folder
            string DomainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority); //to get domain name
            return DomainName + "/UploadImages" + Name;
        }
    }
}