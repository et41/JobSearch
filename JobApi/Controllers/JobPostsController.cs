using JobApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobPostsController : ControllerBase
    {
        private readonly ILogger<JobPostsController> _logger;

        public JobPostsController(ILogger<JobPostsController> logger)
        {
            _logger = logger;
        }
    }
}
