using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobApi.Models.JobPostModels
{
    public class JobCategory
    {
        public int? JobCategoryId { get; set; }
        public string JobCategoryName { get; set; }
        public virtual ICollection<JobPost>? JobPosts { get; set; }
    }
}
