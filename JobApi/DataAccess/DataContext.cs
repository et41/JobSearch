using JobApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }  
        public DbSet<JobLocation> JobLocations { get; set; }
        public DbSet<JobType> JobTypes { get; set; } 
        public DbSet<JobSkill> JobSkills { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<JobCategory>()
                .HasIndex(category => category.JobCategoryName)
                .IsUnique();
            builder.Entity<JobSkill>()
                .HasIndex(skill => skill.SkillName)
                .IsUnique();
            builder.Entity<JobType>().HasData(
                new JobType
                {
                    JobTypeId = 1,
                    JobTypeName = "remote",
                });
            builder.Entity<JobCategory>().HasData(
                new JobCategory
                {
                    JobCategoryId = 1,
                    JobCategoryName = "backend developer"
                });
            builder.Entity<JobLocation>().HasData(
                new JobLocation 
                { 
                    JobLocationId = 1,
                    StreetAddress = "Buyukdere",
                    City = "Istanbul",
                    Country = "Turkey",
                });
           /* builder.Entity<JobSkill>().HasData(
                new JobSkill
                {
                    JobSkillId = 1,
                    SkillName = "C#"
                });
            builder.Entity<JobSkill>().HasData(
                new JobSkill
                {
                    JobSkillId = 2,
                    SkillName = "Python"
                });*/

        }
    }
}
