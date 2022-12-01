using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;
using JobApi.Models.UserAccountModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace JobApi.Models
{
    public class JobPostActivity
    {
        [Key]
        public int JobActivityId { get; set; }
        public DateTime AppliedAt { get; set; }

        public int? AppliedJobId { get; set; }
        public virtual JobPost? JobPost { get; set; }
        public virtual UserAccount? UserAccount { get; set; }
    }
}
