using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        public ActionResult Details()
        {
            var employees = _employeeService.GetAllEmployees();
            return View(employees);
        }

        public ActionResult AddNewEmployee()
        {
            //var employees = _employeeService.AddNewEmployee(Employee);

            return View();
        }

        [HttpPost]
        public ActionResult AddNewEmployee(Employee NewEmployee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddNewEmployee(NewEmployee);
                return RedirectToAction("Details");
            }
            return View();
        }
        public ActionResult DeleteEmployee()
        {
            var model = new EmployeeViewModel
            {
                AllEmployeesFromDatabase = _employeeService.GetAllEmployees().AsEnumerable<Employee>()
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult DeleteEmployee(EmployeeViewModel vm)
        {
            if (vm != null)
            {
                Employee emp = _employeeService.FindEmployeeById(vm.EmployeeIdToDelete);
                _employeeService.DeleteEmployee(emp);
                return RedirectToAction("Details");

            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var employee = _employeeService.FindEmployeeById(id);
            if (employee == null)
            {
                // no employee with the specified id was found
                return HttpNotFound();
            }
            return View(employee);
        }


        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {

                if (employee.EmployeeId <= 0)
                {
                    _employeeService.AddNewEmployee(employee);
                }

                else
                {
                    _employeeService.EditEmployee(employee);
                }


                return RedirectToAction("Details");

            }

            return View();

        }











        //public ActionResult EditEmployee(EmployeeViewModel ve)
        //{

        //    var model = new EmployeeViewModel();


        //    if (ve != null)

        //    {
        //        Employee emp = _employeeService.FindEmployeeById(ve.EmployeeIdToEdit);
        //    }

        //    return View(model);

        //}


        //public ActionResult ChooseEmployeeToEdit()
        //{
        //    var model = new EmployeeViewModel
        //    {
        //        AllEmployeesFromDatabase = _employeeService.GetAllEmployees().AsEnumerable<Employee>()
        //    };
        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult ChooseEmployeeToEdit(int id)
        //{
        //    Employee emp = _employeeService.FindEmployeeById(id);

        //    return View(model);
        //}


        //public ActionResult EditEmployee(int id)
        //{
        //    return View("EditEmployee", _employeeService.FindEmployeeById(id));
        //}

        //public ActionResult SaveEmployee(Employee emptoedit)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (emptoedit.EmployeeId <= 0)
        //        {
        //            _employeeService.AddNewEmployee(emptoedit);
        //        }

        //        else
        //        {
        //            _employeeService.EditEmployee(emptoedit);
        //        }

        //        return RedirectToAction("Index");
        //    }

        //    return View(emptoedit);

        //}



        //public ActionResult EditEmployee()
        //{

        //    var editmodel = new EmployeeViewModel

        //    {
        //        AllEmployeesFromDatabase = _employeeService.GetAllEmployees().AsEnumerable<Employee>()
        //    };

        //    return View(editmodel); 

        // }

        //[HttpPost]
        //public ActionResult EditEmployee(EmployeeViewModel vm)
        //{
        //    if (vm != null)
        //    {
        //        Employee emp = _employeeService.FindEmployeeById(vm.EmployeeIdToEdit);
        //        _employeeService.EditEmployee(emp);
        //        return RedirectToAction("Details");

        //    }
        //    return View();
        //}







    }
} 