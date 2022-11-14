using AutoMapper;
using JobApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

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
            if (jobpost != null)
            {
                var _mappedJobPost = _mapper.Map<JobPost>(jobpost);
                // compare names and find the matching id if not create id
                try
                {
                    var id = _context.JobCategories.First(s => s.JobCategoryName == jobpost.JobCategoryName).JobCategoryId;
                    _mappedJobPost.JobCategoryId = id;
                }
                catch (Exception)
                {
                    _mappedJobPost.JobCategory = new JobCategory() { JobCategoryName = jobpost.JobCategoryName };
                }
                try
                {
                    var id = _context.JobTypes.First(s => s.JobTypeName == jobpost.JobTypeName).JobTypeId;
                    _mappedJobPost.JobTypeId = id;
                }
                catch (Exception)
                {
                    _mappedJobPost.JobType = new JobType() { JobTypeName = jobpost.JobTypeName };
                }
                if (jobpost.JobLocation != null)
                {
                    try
                    {
                        _mappedJobPost.JobLocation = new JobLocation() { City = jobpost.JobLocation.City, Country = jobpost.JobLocation.Country, StreetAddress = jobpost.JobLocation.StreetAddress };
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                await _context.Set<JobPost>().AddAsync(_mappedJobPost);
                await _context.SaveChangesAsync();
            }
        } 
        public async Task<List<JobPost>> GetAllJobPost()
        {

            var posts = await _context.Set<JobPost>()
                .Include(c => c.JobType)
                .Include(c => c.JobLocation).ToListAsync();
            return posts;
        }
    }
}
