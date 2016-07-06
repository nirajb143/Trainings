using RoutingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingSample.Controllers
{
    [RouteArea("EmployeeDetails")]
    [RoutePrefix("Employee")]    
    public class EmployeeController : Controller
    {

        private List<Employee> Employees = new List<Employee>()
        {
            new Employee(){ Id=1, FirstName = "Niraj", LastName="Birajdar", Email = "niraj_birajdar@infosys.com" ,Contact="9823540540", DOB = new DateTime(1984,8,28), Salary=840000.00},
            new Employee(){ Id=2, FirstName = "Chetan", LastName="Lad", Email = "Chetan_Lad@infosys.com", Contact="8907689987", DOB = new DateTime(1985,7,21), Salary=800000.00},
            new Employee(){ Id=3, FirstName = "Girish", LastName="Kulkarni", Email = "girish_kulkarni@gmail.com", Contact="9860115544", DOB = new DateTime(1983,5,1), Salary=960000.00},            

        };
        
        [Route("List")]        
        public ActionResult Index()
        {
            var model = Employees;
            Session["EmployeeList"] = Employees;
            return View(model);
        }       

        [Route("EditDetails/{id:int}")]
        public ActionResult Edit( int id)
        {
            var employeeList = Session["EmployeeList"] as List<Employee>;
            Employee model = employeeList.Single(emp => emp.Id == id);
            return View(model);
        }

        [Route("Edit"),HttpPost]        
        public ActionResult Edit(Employee employee)
        {
            var employeeList = Session["EmployeeList"] as List<Employee>;
            Employee model = employeeList.Single(emp => emp.Id == employee.Id);
            model = employee;
            return RedirectToAction("Index");
        }


        [Route("GetDetails/{fname}/{id}")]
        public ActionResult GetEmployeeDetails(int? id,string fname)
        {
            var employeeList = new List<Employee>()
        {
            new Employee(){ Id=1, FirstName = "Niraj", LastName="Birajdar", Email = "niraj_birajdar@infosys.com" ,Contact="9823540540", DOB = new DateTime(1984,8,28), Salary=840000.00},
            new Employee(){ Id=2, FirstName = "Chetan", LastName="Lad", Email = "Chetan_Lad@infosys.com", Contact="8907689987", DOB = new DateTime(1985,7,21), Salary=800000.00},
            new Employee(){ Id=3, FirstName = "Girish", LastName="Kulkarni", Email = "girish_kulkarni@gmail.com", Contact="9860115544", DOB = new DateTime(1983,5,1), Salary=960000.00},            

        };
        
            if (id != null)
            {
                Employee model = employeeList.Single(emp => emp.Id == id.Value || emp.FirstName.Equals(fname));
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new EmptyResult();
            }
        }
	}
}