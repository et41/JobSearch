namespace JobApi.Models
{
    public class SeekerExperienceDetail
    {
        public int SeekerExperienceDetailId { get; set; }
        public string JobTitle { get; set; }
        public bool isWorking { get; set; }
        public int ExperienceYear { get; set; }
        public int? SeekerProfieId { get; set; }
        public SeekerProfile? SeekerProfile { get; set; }

    }
}
