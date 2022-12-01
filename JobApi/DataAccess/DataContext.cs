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

            builder.Entity<UserType>().HasData(
                new UserType
                {
                    UserTypeId = 1,
                    UserTypeName = "company",
                });

             builder.Entity<UserType>().HasData(
                new UserType
                {
                    UserTypeId = 2,
                    UserTypeName = "seeker",
                });

            builder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    UserAccountId = 1,
                    Email = "arcelik@arcelik.com",
                    Password = "aa",
                    UserTypeId = 1,
                }) ;
            builder.Entity<UserAccount>().HasData(
                new UserAccount
                {
                    UserAccountId = 2,
                    Email = "nazliaktay@gmail.com",
                    Password = "aa",
                    UserTypeId = 2,
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
