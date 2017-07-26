using System.Data.Entity;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmployeeService

    {
        private readonly Migrations.ApplicationDbContext _context;
        public EmployeeService()
        {
            _context = new Migrations.ApplicationDbContext();
        }
        public IQueryable<Employee> GetAllEmployees()
        {
            return _context.Employees.AsQueryable();
        }

        public void AddNewEmployee(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public Employee FindEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void DeleteEmployee(Employee entity)
        {
            //Employee emp = _context.Employees.Find(entity);
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public void EditEmployee (Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}