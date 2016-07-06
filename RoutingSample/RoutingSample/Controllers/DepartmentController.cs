using RoutingSample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoutingSample.Controllers
{
    [RouteArea("Company")]
    [RoutePrefix("DeptPrefix")]
    //[Route("{action}")]

    public class DepartmentController : Controller
    {

        private List<Department> Ddept = new List<Department>()
        {
            new Department(){ Id=1, DeptName="Admin"},
            new Department(){ Id=2, DeptName="HR"},
            new Department(){ Id=3, DeptName="IT"}
        };

        //
        // GET: /Department/

        //[Route("DeptList")]        
        public ActionResult Index()
        {
            return View(Ddept);
        }

        //[Route("GetDetails/{str:int}")]
        [Route("GetDetails/{str}")]
        public ActionResult GetName(string str) {

         //   return View("DeptView");

            var dept = Ddept.Select(d => d).Where(d=>d.DeptName==(str) ).ToList();
            return Json(dept, JsonRequestBehavior.AllowGet);

        }
        [Route("GetDetails/{fname:int}/{id?}")]
        public ActionResult GetMoreData(int fname,string id) {
            return View("DeptView");
        }

        [Route("~/categories")]
        public ActionResult Categories()
        {
            return View("Index", Ddept);
        }

        [Route("customers/{customerId?}/{orders:int}")]
        public IEnumerable GetOrdersByCustomer(int? customerId, int orders)
        {
            //TO DO
            return Ddept;
        }
	}
}