namespace JobApi.Models
{
    public class JobCategory
    {
        public int JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public ICollection<JobPost>? JobPosts { get; set; } 
    }
}
