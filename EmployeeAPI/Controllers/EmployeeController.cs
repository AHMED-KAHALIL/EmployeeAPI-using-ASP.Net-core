using EmployeeAPI.Models;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => EmployeeService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmp(int id)
        {
            var employee = EmployeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            EmployeeService.Add(employee);
            return CreatedAtAction(nameof(Create), new { id = employee.Id }, employee);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            var existingEmployee = EmployeeService.Get(id);
            if (existingEmployee is null)
                return NotFound();

            EmployeeService.Update(employee);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id )
        {
            var employee = EmployeeService.Get(id);
            if(employee is null)
                return NotFound();
            EmployeeService.Delete(id);
            return NoContent();

        }

    }
}
