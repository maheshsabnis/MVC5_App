using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using MVC5_App.Models;
using MVC5_App.Services;
using MVC5_App.CustomFilters;
namespace MVC5_App.Controllers
{

    /// <summary>
    /// Inject the DepartmentService type using the COnstructor Injection
    /// </summary>
    /// 

    // The standard Exception Filter in MVC 
    // server-side auto error navigation by MVC
    // plase ser <customError mode="on"> in web.config file
    [HandleError(ExceptionType =typeof(Exception), View ="Error")]
    // Custom Log Filter
   // [LogFilter]
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
            //try
            //{
                if (ModelState.IsValid)
                {
                    if (dept.DeptNo < 0)
                        throw new Exception("DeptNo Cannot be Zero");
                    deptService.CreayeAsync(dept);
                    // go to Index action method of same controller
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(dept);
                }
            //}
            //catch (Exception ex)
            //{
            //    return View("Error", new HandleErrorInfo(
            //          ex, RouteData.Values["controller"].ToString(),
            //          RouteData.Values["action"].ToString()
            //        ));
               
            //}
        }

        /// <summary>
        /// a Common method for all action methods in the controller
        /// </summary>
        /// <param name="filterContext"></param>
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    // handle the exception to completye the current request exceution
        //    // so that error response can be send back to the client
        //    filterContext.ExceptionHandled = true;
        //    // read the exception
        //    Exception ex = filterContext.Exception;
        //    // generate the response result
        //    ViewDataDictionary viewData = new ViewDataDictionary();
        //    viewData["ControllerName"] = filterContext.RouteData.Values["controller"].ToString();
        //    viewData["ActionName"] = filterContext.RouteData.Values["action"].ToString();
        //    viewData["ErrorMessage"] = ex.Message;

        //    var viewResult = new ViewResult();
        //    viewResult.ViewName = "CustomError";
        //    viewResult.ViewData = viewData;

        //    filterContext.Result = viewResult; 
        //}

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

        public ActionResult Details(int id)
        {
            // saveing data in TempData
            TempData["DeptNo"] = id;
            return RedirectToAction("Index", "Employee");
        }

    }
}