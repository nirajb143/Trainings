using Demo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class ViewBagController : Controller
    {
        //
        // GET: /ViewBag/

        public ActionResult Index()
        {
            StudentDTO student = new StudentDTO()
            {
                 City = "Pune",
                  Class = "MVC",
                   Country = "India",
                    Email = "birajdar.niraj@gmail.com",
                     EnrollYear = "2016",
                      Name = "Niraj",
                       StudentID = 1,
            };

            ViewData["StudentDetails"] = student;
            var schoolName = TempData.Peek("SchoolName").ToString();
            return View();
        }

        public ActionResult Index2()
        {

            if (ViewBag.Student == null)
            {
                StudentDTO student = new StudentDTO()
                {
                    City = "Pune",
                    Class = "MVC",
                    Country = "India",
                    Email = "birajdar.niraj@gmail.com",
                    EnrollYear = "2016",
                    Name = "Niraj",
                    StudentID = 1,
                };

                ViewBag.Student = student;
                TempData["SchoolName"] = "Phenocare";
                TempData.Keep("SchoolName");
            }
            return View();
        }

    }
}
