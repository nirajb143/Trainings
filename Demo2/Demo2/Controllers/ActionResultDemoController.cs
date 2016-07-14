using Demo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class ActionResultDemoController : Controller
    {
        //
        // GET: /ActionResultDemo/

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult IndexWithModel()
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
            return View(student);
        }

        public ViewResult IndexViewName()
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

            return View(@"~\Views\Student\Details.cshtml",student);
        }

        public JsonResult IndexJsonResult()
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

            return Json(student,JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult IndexJavaScriptResult()
        {
            var script = "alert('Hello');";
            return new JavaScriptResult() { Script = script };
            //return JavaScript("alert('Hello');");
        }

        public FileResult IndexWithFileResult()
        {
            return File(@"C:\Users\niraj\Desktop\AngularJs.pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation","AngularJsNew.pptx");
        }



    }
}
