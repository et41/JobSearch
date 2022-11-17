using JobApi.Models.DTOS.CompanyDTOS;
using JobApi.Models.JobPostModels;

namespace JobApi.Models.DTOS.JobPostDTOS
{
    public class JobPostDTO
    {
        public string JobName { get; set; }
        public string JobTypeName { get; set; }
        public string? Description { get; set; }
        public virtual JobCategoryPostDTO JobCategory { get; set; }
        public virtual CompanyForJobPostDTO Company {get;set;}
        public virtual JobLocationDTO? JobLocation { get; set; }
        public virtual ICollection<JobSkillDTO>? JobSkill { get; set; }
    }
}
