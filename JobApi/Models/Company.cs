using JobApi.Models.JobPostModels;
using JobApi.Models.UserAccountModels;

namespace JobApi.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyURL { get; set; }
        public string? Sector { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount? UserAccount { get; set; }

    }
}
