using JobApi.Models.JobPostModels;

namespace JobApi.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string CompanyURL { get; set; }
        public string Sector { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }

    }
}
