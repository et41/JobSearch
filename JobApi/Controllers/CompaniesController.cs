using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApi.DataAccess;
using JobApi.Models.DTOS.CompanyDTOS;
using AutoMapper;
using JobApi.Models.DTOS.JobPostDTOS;
using AutoMapper.QueryableExtensions;
using JobApi.Models.CompanyModels;

namespace JobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyGetDTO>>> GetCompanies()
        {
            //var data = await _context.Companies.Include(p => p.JobPosts).ThenInclude(p => p.JobSkills)
            //    .Select(s => _mapper.Map<ICollection<JobSkillDTO>>(s.JobPosts.SelectMany(s => s.JobSkills))).ToListAsync();
            var data = await _context.Companies.Include(p => p.JobPosts).ThenInclude(p => p.JobSkills).ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyGetDTO>> GetCompany(int id)
        {
            var company = await _context.Companies.Include(p => p.JobPosts).ThenInclude(p => p.JobSkills).FirstOrDefaultAsync(e => e.CompanyId == id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CompanyPostDTO company)
        {
            if (company == null)
                return BadRequest();
            var _mappedCompany = _mapper.Map<Company>(company);
            _context.Companies.Add(_mappedCompany);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
