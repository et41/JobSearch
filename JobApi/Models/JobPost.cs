namespace JobApi.Models
{
    public class JobPost : BaseEntity
    {
        public string JobName { get; set; }
        public string JobTypeName { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string JobCategoryName { get; set; }
        public int? JobCategoryId { get; set; }
        public virtual JobCategory JobCategory { get; set; }
        public int? JobLocationId { get; set; }
        public virtual JobLocation? JobLocation { get; set; }
        public int? JobTypeId { get; set; }
        public virtual JobType? JobType { get; set; }
        public virtual ICollection<JobSkill>? JobSkills { get; set; }

    }
}
