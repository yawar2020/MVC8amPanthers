using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC8amPanthers.Models
{
    public class Employee
    {
        public int Empid { get; set; }
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
    }

    public class Department {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

    public class Empdepartment
    {
        public List<Employee> Empobj { get; set; }
        public Department Deptobj { get; set; }

    }
}