using Microsoft.AspNetCore.Mvc;
using MVC6amCoreBatch_Ravi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6amCoreBatch_Ravi.Controllers
{
    public class DataAccessController : Controller
    {
        AdoDotNetContext db = new AdoDotNetContext();
        public IActionResult Index()
        {
            return View(db.GetEmployees());
        }

       public IActionResult Index2()
        {
            return View(db.GetEmployeesUsingDapper());
        }
    }
}
