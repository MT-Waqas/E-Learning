using E_Learning_Management_System.Models;
using E_Learning_Management_System.Models.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace E_Learning_Management_System.Controllers
{
    public class SchoolController : Controller
    {
        School schl = new School();
        // GET: School
        public ActionResult Schools()
        {
            return View(BL_School.GetSchools());
        }
        public ActionResult School(int? ID)
        {
            if (ID > 0)
            {
                schl.SchoolID = ID;
                schl = BL_School.GetSchools(schl)[0];
                return View(schl);
            }
            else
            {
                return View();
            }
        }
        public string UploadImage(HttpPostedFileBase Image)
        {
            string Name = Path.GetFileName(Image.FileName); //getting name of file
            string extension = Path.GetExtension(Name);//getting extension of file
            Name = Guid.NewGuid() + "_" + DateTime.Now.ToString("yyyyMMdhhmmss") + extension; //generating unique name of file
            string path = Path.Combine("~/UploadImages/" + Name);
            Image.SaveAs(Server.MapPath(path));//Save image in the specific Folder
            string DomainName = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority); //to get domain name
            return DomainName + "/UploadImages/" + Name;
        }
        [HttpPost]
        public ActionResult School(School school)
        {
            if (ModelState.IsValid)
            {
                if (school.UploadFile.ContentLength > 0)
                {
                    string FullPath = UploadImage(school.UploadFile);
                    school.Image = FullPath;
                }
                else
                {
                    School s = new School();
                    s.SchoolID = school.SchoolID;
                    s = BL_School.GetSchools()[0];
                    school.Image = s.Image;
                }
                if (school.SchoolID > 0)
                {
                    BL_School.Save(school, false);//Update 
                }
                else
                {
                    BL_School.Save(school);
                }
                return RedirectToAction("Schools", "School");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int ID)
        {
            BL_School.Delete(ID);
            return RedirectToAction("Index", "School");
        }

    }
}