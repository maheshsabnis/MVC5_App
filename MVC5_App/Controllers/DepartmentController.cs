using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MVC5_App.Models;
using MVC5_App.Services;
namespace MVC5_App.Controllers
{

    /// <summary>
    /// Inject the DepartmentService type using the COnstructor Injection
    /// </summary>
    public class DepartmentController : Controller
    {

        private readonly IService<Department, int> deptService;
        public DepartmentController(IService<Department, int> deptService)
        {
            this.deptService = deptService;
        }

        // GET: Department
        public ActionResult Index()
        {
            var result = deptService.GetAsync();
            return View(result);
        }

        public ActionResult Create()
        {
            var dept = new Department();
            return View(dept);
        }

        [HttpPost]
        public ActionResult Create(Department dept)
        {
            deptService.CreayeAsync(dept);
            // go to Index action method of same controller
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var dept =deptService.GetAsync(id);
            return View(dept);
        }

        [HttpPost]
        public ActionResult Edit(int id, Department dept)
        {
            deptService.UpdateAsync(id, dept);
            // go to Index action method of same controller
            return RedirectToAction("Index");
        }

    }
}