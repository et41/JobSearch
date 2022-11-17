namespace JobApi.Models.DTOS.SeekerDTOS
{
    public class SeekerProfilePutDTO
    {
        public int? SeekerProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SeekerExperienceDetail? SeekerExperienceDetail { get; set; }
        public SeekerEducationDetail? SeekerEducationDetail { get; set; }
        public ICollection<SeekerSkillPutDTO>? SeekerSkills { get; set; }
    }
}
