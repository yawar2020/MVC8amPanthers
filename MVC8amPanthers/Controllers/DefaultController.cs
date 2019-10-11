using MVC8amPanthers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC8amPanthers.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        StudentDetail db = new StudentDetail();
        public ViewResult GetStudnetDetail() {

            var Empmodel = db.GetStudents().ToList();
            return View(Empmodel);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student obj)
        {
            int i = db.SaveStudents(obj);
            if (i > 0)
                return RedirectToAction("GetStudnetDetail");
            else
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            Student s = db.GetStudentsById(id);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Student s)
        {
            int i = db.UpdateStudents(s);
            if (i > 0)
                return RedirectToAction("GetStudnetDetail");
            else
                return View();
         
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Student s = db.GetStudentsById(id);
            return View(s);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            int i = db.DeleteStudents(id);
            if (i > 0)
                return RedirectToAction("GetStudnetDetail");
            else
                return View();
        }
    }
}







