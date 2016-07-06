using RoutingSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingSample.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> customers = new List<Customer>()
        {
            new Customer(){ Id=1, FirstName = "Niraj", LastName="Birajdar", Email = "niraj_birajdar@infosys.com" ,Contact="9823540540", DOB = new DateTime(1984,8,28), Salary=840000.00},
            new Customer(){ Id=2, FirstName = "Chetan", LastName="Lad", Email = "Chetan_Lad@infosys.com", Contact="8907689987", DOB = new DateTime(1985,7,21), Salary=800000.00},
            new Customer(){ Id=3, FirstName = "Girish", LastName="Kulkarni", Email = "girish_kulkarni@gmail.com", Contact="9860115544", DOB = new DateTime(1983,5,1), Salary=960000.00},            
        };

        
        // GET: /Customer/
        [ActionName("CustomerList")]
        public ActionResult Index()
        {
            string test = TempData.Peek("Test").ToString();
            var model = customers;
            return View(model);
        }

        public ActionResult GetCustomerByBirthDate(DateTime birthDate)
        {
            var customer = customers.Single(cust=>cust.DOB.Equals(birthDate));
            return Json(customer, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCustomerByName(string firstName, string lastName)
        {
            var customer = customers.Single(cust => cust.FirstName.Equals(firstName) || cust.LastName.Equals(lastName));
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectToGoogle()
        {
            return Redirect("http://www.google.com"); 
        }

        public ActionResult RedirectToActionDemo()
        {
            TempData["Test"] = "test1";
            TempData.Keep();
            return RedirectToAction("Index");
        }

        public ActionResult FileResultDemo()
        {
            FileStream fileStream = new FileStream(@"D:\sample.txt", FileMode.Open, FileAccess.Read);


            return File(fileStream,"application/txt","TestFieDownload.txt");
        }
	}
}