using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public Employee Add(Employee emp)
        {
             _context.employees.Add(emp);
             _context.SaveChanges();
             return emp;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            return _context.employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.employees.Find(id);
        }
    }
}
