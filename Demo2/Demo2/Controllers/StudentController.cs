using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo2.Models;

namespace Demo2.Controllers
{
    public class StudentController : Controller
    {
        private SchoolManagementEntities db = new SchoolManagementEntities();

        //
        // GET: /Student/

        public ActionResult Index()
        {
            var dbEmployeeList = db.Students.ToList();
            List<StudentDTO> model = dbEmployeeList.Select(student => new StudentDTO() { 
                StudentID = student.StudentID,
                Name = student.Name,
                Email=student.Email,
                City = student.City,
                Class = student.Class,
                Country = student.Country,
                EnrollYear = student.EnrollYear
                   
            }).ToList();

            return View(model);
        }

        //
        // GET: /Student/Details/5

        public ActionResult Details(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            StudentDTO model = new StudentDTO() {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email,
                City = student.City,
                Class = student.Class,
                Country = student.Country,
                EnrollYear = student.EnrollYear             
            };

            return View(model);
        }

        //
        // GET: /Student/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Student/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentDTO student)
        {            
            if (ModelState.IsValid)
            {
                Student dbStudent = new Student() {
                    StudentID = student.StudentID,
                    Name = student.Name,
                    Email = student.Email,
                    City = student.City,
                    Class = student.Class,
                    Country = student.Country,
                    EnrollYear = student.EnrollYear  
                };
                db.Students.Add(dbStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //
        // GET: /Student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            StudentDTO model = new StudentDTO()
            {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email,
                City = student.City,
                Class = student.Class,
                Country = student.Country,
                EnrollYear = student.EnrollYear
            };

            return View(model);
        }

        //
        // POST: /Student/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                Student dbStudent = db.Students.Find(student.StudentID);
                
                dbStudent.Name = student.Name;
                dbStudent.Email = student.Email;
                dbStudent.City = student.City;
                dbStudent.Class = student.Class;
                dbStudent.Country = student.Country;
                dbStudent.EnrollYear = student.EnrollYear;

                db.Entry(dbStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        //
        // GET: /Student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Student student = db.Students.Find(id);
           

            if (student == null)
            {
                return HttpNotFound();
            }

            StudentDTO model = new StudentDTO()
            {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email,
                City = student.City,
                Class = student.Class,
                Country = student.Country,
                EnrollYear = student.EnrollYear
            };

            return View(model);
        }

        //
        // POST: /Student/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}