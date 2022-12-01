using System.ComponentModel.DataAnnotations;

namespace JobApi.Models.UserAccountModels
{
    public class UserType
    {
        public int UserTypeId {get;set;}
        public string UserTypeName { get; set; }
        public ICollection<UserAccount>? UserAccounts { get; set; }
    }
}
