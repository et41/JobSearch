namespace JobApi.Models.DTOS.JobPostDTOS
{
    public class JobPostGetDTO
    {
        public int Id { get; set; }
        public string JobName { get; set; }
        public string JobTypeName { get; set; }
        public string JobCategoryName { get; set; }
        public string? Description { get; set; }
        public virtual JobLocationDTO? JobLocation { get; set; }
        public string CompanyName { get; set; }
        public ICollection<JobSkillDTO> JobSkills { get; set; }
    }
}
