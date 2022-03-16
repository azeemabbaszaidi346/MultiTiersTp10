using BusinessAccessLayer;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using multitiermvc.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace multitiermvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BLEmployeesBusiness business = new BLEmployeesBusiness();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var emp = business.GetEmployees();
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees employee)
        {
            var result = business.createEmployees(employee);
            if (result)
            {
                return RedirectToAction("index");
            }
            else
            {
                ModelState.AddModelError("error", "Error in create employee !");
                return View(employee);
            }


        }

      
        public IActionResult Update(int id)
        {
            var user = business.GetEmployeesbyId(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Update(Employees employee)
        {

            var user = business.UpdateeEmployees(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            business.DeleteEmployee(id);
            return RedirectToAction("Index");

        }
    }
 }
