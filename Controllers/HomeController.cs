using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC6amCoreBatch_Ravi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6amCoreBatch_Ravi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("Home/index/{id?}")]
        public IActionResult Index(int? id)
        {
            return Content(id.ToString());
        }
       [Route("Movie/jungle/{id=1}")]
        [Route("Movie/jungle2/{id:int}")]
        public IActionResult Privacy(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public RedirectResult GetView()
        {
            return Redirect("http://www.google.com");
        }

        public RedirectToActionResult GetView2()
        {
            return RedirectToAction("Privacy");
        }

        public JsonResult GetJson()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "helloWorld";
            emp.EmpSalary = 1000;

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 1;
            emp1.EmpName = "test";
            emp1.EmpSalary = 2000;

            List<EmployeeModel> listobj = new List<EmployeeModel>();
            listobj.Add(emp);
            listobj.Add(emp1);

            return Json(listobj);
        }


        public ViewResult FirstPartialView()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "helloWorld";
            emp.EmpSalary = 1000;

            EmployeeModel emp1 = new EmployeeModel();
            emp1.EmpId = 1;
            emp1.EmpName = "test";
            emp1.EmpSalary = 2000;

            List<EmployeeModel> listobj = new List<EmployeeModel>();
            listobj.Add(emp);
            listobj.Add(emp1);

            return View(listobj);
        }

        [HttpPost]
        public ViewResult FirstPartialView(EmployeeModel emp)
        {
            return View();
        }
        [Route("home/taghelper")]
public ActionResult tagHelperExample()
        {
            EmployeeModel emp = new EmployeeModel();
            emp.EmpId = 1;
            emp.EmpName = "test";
            emp.EmpSalary = 210000;

            return View(emp);
        }

    }
}
