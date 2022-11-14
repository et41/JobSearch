namespace JobApi.Models
{
    public class JobCategory
    {
        public int? JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; } 
    }
}
