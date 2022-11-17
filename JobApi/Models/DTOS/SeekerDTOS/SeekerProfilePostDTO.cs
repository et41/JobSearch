namespace JobApi.Models.DTOS.SeekerDTOS
{
    public class SeekerProfilePostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SeekerExperienceDetailDTO? SeekerExperienceDetail { get; set; }
        public SeekerEducationDetailDTO? SeekerEducationDetail { get; set; }
        public ICollection<SeekerSkillDTO>? SeekerSkills { get; set; }
    }
}
