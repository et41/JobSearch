using JobApi.Models;

namespace JobApi.DataAccess
{
    public interface IJobPostsRepository : IGenericRepository<JobPost>
    {
        Task CreateJobPost(JobPostDTO jobpost);
        Task<List<JobPost>> GetAllJobPost();
        //JobPost GetAllMapper();
    }
}
