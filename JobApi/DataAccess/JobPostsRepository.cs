using AutoMapper;
using JobApi.Models;
using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;
using JobApi.Models.UserAccountModels;
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
        public async Task CreateJobPost(JobPostDTO jobpost, int userid)
        {

            string? usertype = _context.UserAccounts.Include(p => p.UserType).FirstOrDefault(p => p.UserAccountId == userid).UserType.UserTypeName;
            if(jobpost != null && usertype == "company")
            {
                JobPost mappedPost = new JobPost()
                {
                    JobName = jobpost.JobName,
                    JobTypeName = jobpost.JobTypeName,
                    Description = jobpost.Description,
                    JobCategory = _mapper.Map<JobCategory>(jobpost.JobCategory),
                    JobLocation = _mapper.Map<JobLocation>(jobpost.JobLocation),
                    JobType = new JobType() { JobTypeName = jobpost.JobTypeName },
                    JobSkills = _mapper.Map<ICollection<JobSkill>>(jobpost.JobSkill),
                    Company = _context.Companies.FirstOrDefault(p => p.UserAccountId == userid),
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
                .Include(c => c.JobCategory)
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
                JobPost postToUpdate = await _context.JobPosts
                  .FirstOrDefaultAsync(c => c.Id == jobpost.Id);

                if(postToUpdate != null)
                {
                    postToUpdate.JobName = jobpost.JobName;
                    postToUpdate.JobTypeName = jobpost.JobTypeName;
                    postToUpdate.Description = jobpost.Description;
                    _context.JobCategories.Update(_mapper.Map<JobCategory>(jobpost.JobCategory));
                    _context.JobLocations.Update(_mapper.Map<JobLocation>(jobpost.JobLocation));
                    _context.JobSkills.UpdateRange(_mapper.Map<ICollection<JobSkill>>(jobpost.JobSkills));
                    _context.Update(postToUpdate);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
