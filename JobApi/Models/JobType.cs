namespace JobApi.Models
{
    public class JobType
    {
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }
    }
}
