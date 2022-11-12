namespace JobApi.Models
{
    public class JobLocation
    {
        public int JobLocationId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string? Country { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }
    }
}
