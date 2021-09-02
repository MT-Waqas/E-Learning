using E_Learning_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Learning_Management_System.Controllers
{
    public class SchoolController : Controller
    {
        // GET: School
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult School(int? ID)
        {
            return View();
        }
        public ActionResult School(School school)
        {
            if (ModelState.IsValid)
            {
                if (school.SchoolID > 0)
                {
                    BL_School.Save(school);
                }
                else
                {
                    BL_School.Save(school, false);
                }
                return RedirectToAction("Index","School");
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