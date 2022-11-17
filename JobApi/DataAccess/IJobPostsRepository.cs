using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;

namespace JobApi.DataAccess
{
    public interface IJobPostsRepository : IGenericRepository<JobPost>
    {
        Task CreateJobPost(JobPostDTO jobpost, int userid);
        Task<List<JobPostGetDTO>> GetAllJobPost();
        Task<JobPostGetDTO> GetByIdJobPost(int id);
        Task UpdateJobPost(JobPostGetDTO jobpost);
        //JobPost GetAllMapper();
    }
}
