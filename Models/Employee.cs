using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee 
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public Sex Gender { get; set; }
        public string City { get; set; }
    }
}