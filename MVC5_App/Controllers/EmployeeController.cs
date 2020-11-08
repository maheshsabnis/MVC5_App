using MVC5_App.Models;
using MVC5_App.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5_App.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IService<Employee, int> empService;
        private readonly IService<Department, int> deptService;

        public EmployeeController(IService<Employee, int> empService,
            IService<Department, int> deptService)
        {
            this.empService = empService;
            this.deptService = deptService;
        }

        // GET: Employee
        public ActionResult Index()
        {
            var res = empService.GetAsync();
            return View(res);
        }

        public ActionResult Create()
        {
            var res = new Employee();
            // SelectList is a MVC CLass thatwill be used
            // to define a List object so that it willbe displayed
            // on View                                              // Data Value Data Text Field
            ViewBag.DeptNo = new SelectList(deptService.GetAsync(), "DeptNo", "DeptName");
            return View(res);
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                var res = empService.CreayeAsync(emp);
                return RedirectToAction("Index");
            }
            else 
            {
                ViewBag.DeptNo = new SelectList(deptService.GetAsync(), "DeptNo", "DeptName");
                return View(emp);
            }
        }

        public JsonResult SalaryAsyncValidator(int Salary)
        {
            if (Salary < 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}