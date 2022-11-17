using AutoMapper;
using JobApi.Models;
using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.Json.Serialization;

namespace JobApi.DataAccess
{
    public class JobPostsRepository : GenericRepository<JobPost>, IJobPostsRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public JobPostsRepository(DataContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateJobPost(JobPostDTO jobpost)
        {
            if(jobpost != null)
            {
                JobPost mappedPost = new JobPost()
                {
                    JobName = jobpost.JobName,
                    JobTypeName = jobpost.JobTypeName,
                    CompanyName = jobpost.CompanyName,
                    Description = jobpost.Description,
                    JobCategoryName = jobpost.JobCategoryName,
                    JobCategory = new JobCategory() { JobCategoryName = jobpost.JobCategoryName },
                    JobLocation = _mapper.Map<JobLocation>(jobpost.JobLocation),
                    JobType = new JobType() { JobTypeName = jobpost.JobTypeName },
                    JobSkills = _mapper.Map<ICollection<JobSkill>>(jobpost.JobSkill),
                };
                await _context.Set<JobPost>().AddAsync(mappedPost);
                await _context.SaveChangesAsync();

            }
         } 
        public async Task<List<JobPostGetDTO>> GetAllJobPost()
        {
            var posts = await _context.Set<JobPost>()
                .Include(c => c.JobType)
                .Include(c => c.JobLocation)
                .Include(c => c.JobSkills)
                .ToListAsync();
            return _mapper.Map<List<JobPostGetDTO>>(posts);
        }
        public async Task<JobPostGetDTO> GetByIdJobPost(int id)
        {
            var postById = await _context.Set<JobPost>()
                .Include(c => c.JobLocation)
                .Include(c => c.JobCategory)
                .Include(c => c.JobSkills)
                .FirstOrDefaultAsync(e => e.Id == id);
            return _mapper.Map<JobPostGetDTO>(postById);
        }
        public async Task UpdateJobPost(JobPostGetDTO jobpost)
        {
            try
            {
                JobPost postToUpdate = await _context.JobPosts.Include(p => p.JobSkills).FirstOrDefaultAsync(c => c.Id == jobpost.Id);
                if(postToUpdate != null)
                {
                    postToUpdate.JobName = jobpost.JobName;
                    postToUpdate.JobTypeName = jobpost.JobTypeName;
                    postToUpdate.Description = jobpost.Description;
                    postToUpdate.CompanyName = jobpost.CompanyName;
                    postToUpdate.JobCategoryName = jobpost.JobCategoryName;
                    postToUpdate.JobLocation = _mapper.Map<JobLocation>(jobpost.JobLocation);
                    if(jobpost.JobSkills != null)
                    {
                        foreach (var item in postToUpdate.JobSkills.ToList())
                        {
                            postToUpdate.JobSkills.Remove(item);
                        }
                        postToUpdate.JobSkills = _mapper.Map<ICollection<JobSkill>>(jobpost.JobSkills);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteJobPost(int id)
        {
        }
    }
}
