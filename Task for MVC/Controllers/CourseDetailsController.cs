using DataAccessLayer;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_for_MVC.Controllers
{
    public class CourseDetailsController : Controller
    {
        ICourseDetailsRepository course = null;
        public CourseDetailsController(IConfiguration configuration, ICourseDetailsRepository cours)
        {
            course = cours;
        }
        // GET: CourseDetailsController
        public ActionResult List()
        {
            var result = course.SelectALLStudent();
            return View("List",result);
        }

        // GET: CourseDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseDetailsController/Create
        public ActionResult Create()
        {
            return View("Add",new CourseDetails());
        }

        // POST: CourseDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseDetails cour)
        {
            try
            {
                course.RegisterUser(cour);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDetailsController/Edit/5
        public ActionResult Edit(string username)
        {
            var edit = course.SelectUserByName(username);
            return View("update",edit);
        }

        // POST: CourseDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseDetails cours)
        {
            try
            {
                course.UpdateUser(cours);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
