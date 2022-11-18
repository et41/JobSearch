using JobApi.Models.DTOS.SeekerDTOS;
using JobApi.Models.UserAccountModels;

namespace JobApi.Models.SeekerProfileModels
{
    public class SeekerProfile
    {
        public int? SeekerProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? SeekerExperienceDetailId { get; set; }
        public SeekerExperienceDetail? SeekerExperienceDetail { get; set; }
        public int? SeekerEducationDetailId { get; set; }
        public SeekerEducationDetail? SeekerEducationDetail { get; set; }
        public ICollection<SeekerSkill>? SeekerSkills { get; set; }
        public int UserAccountId { get; set; }
        public UserAccount? UserAccount { get; set; }
    }
}
