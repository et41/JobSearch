using JobApi.Models.DTOS.CompanyDTOS;
using JobApi.Models.DTOS.SeekerDTOS;

namespace JobApi.Models.DTOS.UserAccountDTOS
{
    public class UserAccountSeekerDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserTypeDTO? UserType { get; set; }
        public SeekerProfilePostDTO? SeekerProfile { get; set; }
    }
}
