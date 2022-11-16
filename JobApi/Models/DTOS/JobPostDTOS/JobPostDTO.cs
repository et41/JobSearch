namespace JobApi.Models.DTOS.JobPostDTOS
{
    public class JobPostDTO
    {
        public string JobName { get; set; }
        public string JobTypeName { get; set; }
        public string? Description { get; set; }
        public string CompanyName { get; set; }
        public virtual JobLocationDTO? JobLocation { get; set; }
        public virtual ICollection<JobSkillDTO>? JobSkill { get; set; }
        public string JobCategoryName { get; set; }
    }
}
