using JobApi.Models.DTOS.UserAccountDTOS;
using System.ComponentModel.DataAnnotations;

namespace JobApi.Models.UserAccountModels
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserType UserType { get; set; }
        public Company? Company { get; set; }
        public SeekerProfile? SeekerProfile { get; set; }
    }
}
