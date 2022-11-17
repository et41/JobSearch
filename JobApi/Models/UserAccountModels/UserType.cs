using System.ComponentModel.DataAnnotations;

namespace JobApi.Models.UserAccountModels
{
    public class UserType
    {
        public int Id {get;set;}
        public string UserTypeName { get; set; }
        public ICollection<UserAccount>? UserAccounts { get; set; }
    }
}
