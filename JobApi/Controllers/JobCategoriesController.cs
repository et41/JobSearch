using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApi.DataAccess;
using JobApi.Models;
using AutoMapper;

namespace JobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public JobCategoriesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<JobCategoryDTO>> GetJobCategories()
        {
            var categories = await _context.Set<JobCategory>()
                .Include(post => post.JobPosts)
                .ThenInclude(post => post.JobLocation)
                .ToListAsync();
            return categories.Select(s => _mapper.Map<JobCategoryDTO>(s)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobCategoryDTO>> GetJobCategory(int? id)
        {
            var category = await _context.Set<JobCategory>()
                .Where(s => s.JobCategoryId == id)
                .Include(post => post.JobPosts)
                .ThenInclude(post => post.JobLocation).FirstOrDefaultAsync();
            

            if (category == null)
            {
                return NotFound();
            }

            return _mapper.Map<JobCategoryDTO>(category);
        }

        // PUT: api/JobCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCategory(int? id, JobCategory jobCategory)
        {
            if (id != jobCategory.JobCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(jobCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCategoryExists(id))
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

        // POST: api/JobCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobCategory>> PostJobCategory(JobCategory jobCategory)
        {
            _context.JobCategories.Add(jobCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobCategory", new { id = jobCategory.JobCategoryId }, jobCategory);
        }

        // DELETE: api/JobCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobCategory(int? id)
        {
            var jobCategory = await _context.JobCategories.FindAsync(id);
            if (jobCategory == null)
            {
                return NotFound();
            }

            _context.JobCategories.Remove(jobCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobCategoryExists(int? id)
        {
            return _context.JobCategories.Any(e => e.JobCategoryId == id);
        }
    }
}
