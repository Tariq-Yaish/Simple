using Microsoft.AspNetCore.Mvc;
using Simple.Context;
using Simple.Models;

namespace Simple.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private static List<Company> companies = new List<Company>()
        {
            new Company
            {
                Company_ID = 1 ,
                Company_Name = "IConnect" ,
                Location = "Birah - Ramallah - Palestine"
            },

            new Company
            {
                Company_ID = 2 ,
                Company_Name = "BioLine" ,
                Location = "AlAhliya - Ramallah - Palestine"
            }
        };

        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await _context.DBCompanies.ToListAsync());
        }

        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var company = await _context.DBCompanies.FindAsync(id);

            if (company == null)
                return BadRequest("Such company doesn't exist in this base");

            return Ok(company);
        }

        [HttpPost("AddACompany")]
        public async Task<ActionResult<List<Company>>> AddCompany(Company newCompany)
        {
            if (newCompany == null)
                return BadRequest("Check your input");

            _context.DBCompanies.Add(newCompany);
            await _context.SaveChangesAsync();

            return Ok(await _context.DBCompanies.ToListAsync());
        }

        [HttpPut("UpdateACompany")]
        public async Task<ActionResult<List<Company>>> Update(Company gCompany)
        {
            var dbCompany = await _context.DBCompanies.FindAsync(gCompany.Company_ID);

            if (dbCompany == null)
                return NotFound();

            dbCompany = new Company(gCompany);
            dbCompany.Location = gCompany.Location;

            await _context.SaveChangesAsync();

            return Ok(await _context.DBCompanies.ToListAsync());
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            var dbCompany = await _context.DBCompanies.FindAsync(id);

            if (dbCompany == null)
                return BadRequest("Such company doesn't exist in this base");

            _context.DBCompanies.Remove(dbCompany);
            await _context.SaveChangesAsync();

            return Ok(await _context.DBCompanies.ToListAsync());
        }
    }
}
