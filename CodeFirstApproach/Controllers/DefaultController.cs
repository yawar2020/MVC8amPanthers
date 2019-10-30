﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproach.Models;

namespace CodeFirstApproach.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        EmployeeContext db = new EmployeeContext();
        public ActionResult Index()
        {
            return View(db.EmployeeModels.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection obj)
        {
            EmployeeModel obj1 = new Models.EmployeeModel();
            obj1.EmpName = obj["EmpName"];
            obj1.EmpSalary = Convert.ToInt32(obj["EmpSalary"]);
            db.EmployeeModels.Add(obj1);
           int i= db.SaveChanges();
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            EmployeeModel obj = db.EmployeeModels.Find(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel emp)
        {
            db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
            int i = db.SaveChanges();
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }

            
        }

        [HttpGet]
        public ActionResult Delete(int? id) {

            EmployeeModel obj = db.EmployeeModels.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {

            EmployeeModel obj = db.EmployeeModels.Find(id);
            db.EmployeeModels.Remove(obj);
            int i = db.SaveChanges();
            if (i > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public ActionResult HtmlHelperExample()
        {
            ViewBag.Employname = new SelectList(db.EmployeeModels, "EmpId", "EmpName",3);
            return View();
        }

        public ActionResult TestViewData()
        {
            //List<string> obj = new List<string>();
            //obj.Add("pratiusha");
            //obj.Add("deepti");
            //obj.Add("Nagini");
            //obj.Add("Anusha");
            //ViewData["Student"] = obj;
            ViewBag.somevalue = "Hello world";
            return RedirectToAction("GetViewDataValue");
        }
        public ActionResult GetViewDataValue()
        {
            TempData["EmployeeInfo"] = "Hello World";
            return RedirectToAction("GetData");
        }
        public ActionResult GetData()
        {
            //string Tempinfo = TempData["EmployeeInfo"].ToString();
            // TempData.Keep();
            string Tempinfo = TempData.Peek("EmployeeInfo").ToString();
            ViewBag.info = Tempinfo;
            return View();
        }

        
    }


}