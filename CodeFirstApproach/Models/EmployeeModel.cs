﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class EmployeeModel
    {
        [Key]
        public int EmpId { get; set; }
        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }
        public int EmpSalary { get; set; }
        public int DeptId { get; set; }
    }

    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}