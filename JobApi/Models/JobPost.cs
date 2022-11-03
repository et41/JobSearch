namespace JobApi.Models
{
    public class JobPost
    {
        public int Id { get; set; }
        public int JobTypeId { get; set; }
        public int CompanyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Description { get; set; }
        public int? JobLocationId { get; set; }
        public bool IsActive { get; set; }
        public int? JobCategoryId { get; set; }
        public JobCategory? JobCategory { get; set; }
        public JobLocation? JobLocation { get; set; }
        public JobType? JobType { get; set; }
    }
}
