using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Task_for_MVC.Models;

namespace Task_for_MVC.Controllers
{
    public class CourseDetailsController : Controller
    {
        ICourseDetailsRepository cours = null;
        public CourseDetailsController(IConfiguration configuration, ICourseDetailsRepository course)
        {
            cours = course;
        }


        public IActionResult List()
        {
            var result = cours.SelectALLStudent();
            return View("List",result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
