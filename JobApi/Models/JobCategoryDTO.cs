namespace JobApi.Models
{
    public class JobCategoryDTO
    {
        public int? JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public virtual ICollection<JobPostDTO>? JobPosts { get; set; }
    }
}
