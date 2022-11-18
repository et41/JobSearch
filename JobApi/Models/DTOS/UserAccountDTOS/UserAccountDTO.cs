using JobApi.Models.DTOS.CompanyDTOS;
using JobApi.Models.DTOS.SeekerDTOS;
using JobApi.Models.UserAccountModels;

namespace JobApi.Models.DTOS.UserAccountDTOS
{
    public class UserAccountDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserTypeDTO? UserType { get; set; }
        public CompanyPostDTO? Company { get; set; }
        public SeekerProfilePostDTO? SeekerProfile { get; set; }
    }
}
