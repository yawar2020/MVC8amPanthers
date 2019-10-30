using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC8amPanthers.Models;

namespace MVC8amPanthers.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetEmployee()
        {
            return View();
        }
        public JsonResult TestEmployee()
        {
            List<Employee> dbobj = new List<Employee>();

            Employee obj = new Employee();
            obj.Empid=1;
            obj.EmpName = "Sujata";
            obj.EmpSalary = 25000;

            Employee obj1 = new Employee();
            obj1.Empid = 2;
            obj1.EmpName = "Saurav";
            obj1.EmpSalary = 35000;

            dbobj.Add(obj);
            dbobj.Add(obj1);

            return Json(dbobj,JsonRequestBehavior.AllowGet);
        }
        public FileResult GetFile()
        {
            return File("~/Web.config", "application/xml","MyWebConfig");
        }

        public ContentResult GetContentData(int ?id)
        {
            if (id == 1)
            {
                return Content("<p style=color:red>Hello World</p>");//css format of data
            }
            else if (id == 2)
            {
                return Content("<script>alert('Hello World')</script>");
            }
            else {
                return Content("Hello World");
            }
        }
    }       
}