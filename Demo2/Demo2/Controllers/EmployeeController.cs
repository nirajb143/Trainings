using Demo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo2.Controllers
{
    public class EmployeeController : Controller
    {

        List<Employee> Employees = new List<Employee>() { 
        new Employee(){ Id=1, Email = "birajdar.niraj@gmail.com", FirstName = "Niraj", LastName ="Birajdar", MobileNumber="9823540540"},
        new Employee(){ Id=2, Email = "birajdar.nimish@gmail.com", FirstName = "Nimish", LastName ="Birajdar", MobileNumber="9823540540"},
        new Employee(){ Id=2, Email = "birajdar.ninad@gmail.com", FirstName = "Ninad", LastName ="Birajdar", MobileNumber="9823540540"},
        };

        public ActionResult Index()
        {

            return View(Employees);
        }

    }
}
