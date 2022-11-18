using JobApi.Models.JobPostModels;
using Microsoft.EntityFrameworkCore;
using JobApi.Models.UserAccountModels;
using JobApi.Models.SeekerProfileModels;
using JobApi.Models.CompanyModels;

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
        public DbSet<SeekerProfile> SeekerProfiles { get; set; }
        public DbSet<SeekerSkill> SeekerSkills { get; set; }
        public DbSet<SeekerEducationDetail> SeekerEducationDetails { get; set; }    
        public DbSet<SeekerExperienceDetail> SeekerExperienceDetails { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<JobCategory>()
                .HasIndex(category => category.JobCategoryName)
                .IsUnique();*/
            /*builder.Entity<JobSkill>()
                .HasIndex(skill => skill.SkillName)
                .IsUnique();*/
            /*builder.Entity<Company>()
                .HasIndex(company => company.CompanyName)
                .IsUnique();*/
            /*builder.Entity<UserType>()
                .HasIndex(usertype => usertype.UserTypeName)
                .IsUnique();*/
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

        public DbSet<JobApi.Models.UserAccountModels.UserAccount> UserAccount { get; set; }
    }
}
