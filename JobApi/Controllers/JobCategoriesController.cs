using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApi.DataAccess;
using AutoMapper;
using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;

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

        [HttpPut]
        public async Task UpdateJobCategory(JobCategoryDTO jobcategory)
        {
            try
            {
                JobCategory categoryToUpdate = await _context.JobCategories
                    .Include(s => s.JobPosts)
                    .FirstOrDefaultAsync(c => c.JobCategoryId == jobcategory.JobCategoryId);
                if(categoryToUpdate != null)
                {
                    categoryToUpdate.JobCategoryId = jobcategory.JobCategoryId;
                    categoryToUpdate.JobCategoryName = jobcategory.JobCategoryName;
                }
                //Check if posts exist under the category
                var existingPosts = categoryToUpdate.JobPosts;
                if(existingPosts != null)
                {
                    foreach(var post in existingPosts)
                    {
                        post.JobCategoryName = jobcategory.JobCategoryName;
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/JobCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostJobCategory(JobCategoryPostDTO jobCategory)
        {
            var mappedJobCategory = _mapper.Map<JobCategory>(jobCategory);
            await _context.Set<JobCategory>().AddAsync(mappedJobCategory);
            await _context.SaveChangesAsync();
        }

       }
}
