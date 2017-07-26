using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeIdToDelete { get; set; }
        public int EmployeeIdToEdit { get; set; }
        public IEnumerable<Employee> AllEmployeesFromDatabase{ get; set; }

    }
}