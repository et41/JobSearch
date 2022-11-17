using System.ComponentModel.DataAnnotations;

namespace JobApi.Models.DTOS.JobPostDTOS
{
    public class JobSkillDTO
    {
        [Key]
        public int? JobSkillId { get; set; }
        public string SkillName { get; set; }
    }
}
