using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthentication.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<Employee>GetEmployee()
        {
            return _employee.GetEmployee();
        }
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee emp)
        {
             _employee.Add(emp);
              return Ok();
        }
    }
    
}