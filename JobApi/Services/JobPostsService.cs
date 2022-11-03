using JobApi.DataAccess;
using JobApi.Models;

namespace JobApi.Services
{
    public class JobPostsService
    {
        private readonly DataContext _context;
        public JobPostsService(DataContext context)
        {
            _context = context;
        }
        public void JobPostsAdd()
        {
            var job = new JobPost()
            {
                JobTypeId = 1,
                CompanyId = 1,
                CreatedDate = Convert.ToDateTime("10/1/2022"),
                Description = "Application development/refactoring in object-oriented language such as Java/Spring. Application hosting" +
                    " on cloud compute services such as Azure App Service," +
                    " Azure Functions and Azure Kubernetes Service. Asynchronous" +
                    " application development using messaging services like Azure Service Bus." +
                    "Security development (utilizing modern authn/authz protocols such as OIDC & OAuth2 with Azure AD and Okta).",
                JobLocationId = 1,
                IsActive = true,
                JobCategoryId = 1,
            };
            _context.JobPosts.Add(job);
            _context.SaveChanges();
        }
    }
}
