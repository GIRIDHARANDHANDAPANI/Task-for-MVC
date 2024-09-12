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
            var result = course.GetAllUsers();
            return View("List",result);
        }

        // GET: CourseDetailsController/Details/5
        public ActionResult Details(string username)
        {
            var edit = course.GetUserByName(username);
            return View("Details",edit);
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
                if (ModelState.IsValid)
                {
                    var result = course.GetUserByName(cour.Name);
                    if (result != null)
                    {
                        ModelState.AddModelError("", "User Name Already Exists");
                        return View("Add", cour);
                    }
                    course.InsertUser(cour);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("Add", cour);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDetailsController/Edit/5
        public ActionResult Edit(string username)
        {
            var edit = course.GetUserByName(username);
            return View("update",edit);
        }

        // POST: CourseDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseDetails cours)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = course.GetUserByName(cours.Name);
                    if (result != null)
                    {
                        ModelState.AddModelError("", "User Name Already Exists");
                        return View("update", cours);
                    }
                    course.UpdateUser(cours);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View("update", cours);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseDetailsController/Delete/5
        public ActionResult Delete(string username)
        {
            var details = course.GetUserByName(username);
            return View("ConfirmDelete",details);
        }

        // POST: CourseDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id, IFormCollection collection)
        {
            try
            {
                course.DeleteUser(id);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
