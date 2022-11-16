namespace JobApi.Models
{
    public class JobSkill
    {
        public int JobSkillId{ get; set; }
        public string SkillName { get; set;}
        public virtual ICollection<JobPost>? JobPosts { get; set; }
    }
}
