using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;

namespace JobApi.Models.DTOS.CompanyDTOS
{
    public class CompanyGetDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyURL { get; set; }
        public string Sector { get; set; }
        public virtual ICollection<JobPostGetDTO>? JobPosts { get; set; }

    }
}
