using Microsoft.AspNetCore.Mvc;
using Simple.Context;
using Simple.Models;

namespace Simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Employee_ID = 1,
                Employee_Name = "Zain",
                Employee_Age = 25,
                Comapny_Id = 1
            },

            new Employee()
            {
                Employee_ID = 2,
                Employee_Name = "Nobody",
                Employee_Age = 22,
                Comapny_Id = 2
            }
        };

        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            return Ok(await _context.DBEmployees.ToListAsync());
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await _context.DBEmployees.FindAsync(id);

            if (employee == null)
                return BadRequest("Such employee doesn't exist in the base");

            return Ok(employee);
        }

        [HttpPost("AddAnEmployee")]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return BadRequest("Check your input");

            _context.DBEmployees.Add(newEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.DBEmployees.ToListAsync());
        }

        [HttpPut("UpdateAnEmployee")]
        public async Task<ActionResult<List<Employee>>> Update(Employee gEmpolyee)
        {
            var dbEmployee = await _context.DBEmployees.FindAsync(gEmpolyee.Employee_ID);

            if (dbEmployee == null)
                return NotFound();

            dbEmployee = new Employee(gEmpolyee);

            await _context.SaveChangesAsync();

            return Ok(await _context.DBEmployees.ToListAsync());
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<List<Employee>>> Delete(int id)
        {
            var dbEmployee = await _context.DBEmployees.FindAsync(id);

            if (dbEmployee == null)
                return BadRequest("Such employee doesn't exist in the base");

            _context.DBEmployees.Remove(dbEmployee);
            await _context.SaveChangesAsync();

            return Ok(await _context.DBEmployees.ToListAsync());
        }
    }
}
