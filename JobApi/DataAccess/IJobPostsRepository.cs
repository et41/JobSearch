using JobApi.Models;

namespace JobApi.DataAccess
{
    public interface IJobPostsRepository : IGenericRepository<JobPost>
    {
        Task CreateJobPost(JobPostDTO jobpost);
        Task<List<JobPostGetDTO>> GetAllJobPost();
        Task<JobPostGetDTO> GetByIdJobPost(int id);
        Task UpdateJobPost(JobPostGetDTO jobpost);
        //JobPost GetAllMapper();
    }
}
