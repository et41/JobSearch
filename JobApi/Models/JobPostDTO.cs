namespace JobApi.Models
{
    public class JobPostDTO
    {
        public string JobName { get; set; } 
        public string JobTypeName { get; set; }
        public string? Description { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
    }
}
