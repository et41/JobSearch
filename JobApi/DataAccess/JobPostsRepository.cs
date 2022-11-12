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
            var _mappedJobPost = _mapper.Map<JobPost>(jobpost);
            await _context.Set<JobPost>().AddAsync(_mappedJobPost);
            await _context.SaveChangesAsync();
        }
        public JobPost GetAllMapper()
        {
            var data = _context.Set<JobPost>().AsNoTracking();
            return _mapper.Map<JobPost>(data);
        }

    }
}
