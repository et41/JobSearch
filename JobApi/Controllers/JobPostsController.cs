using JobApi.DataAccess;
using JobApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("api/jobs/[controller]")]
    public class JobPostsController : ControllerBase
    {
        private readonly ILogger<JobPostsController> _logger;
        private readonly IJobPostsRepository _repository;

        public JobPostsController(ILogger<JobPostsController> logger, IJobPostsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public JobPost GetAllMapper()
        {
            return _repository.GetAllMapper();
        }
        /*public async Task<ActionResult<JobPost>> Get()
        {
            var data = _repository.GetAll();
            return Ok(data);
        }*/
        [HttpPost]
        public async Task<ActionResult<JobPostDTO>> Add(JobPostDTO jobpost)
        {
            await _repository.CreateJobPost(jobpost);
            return Ok(_repository.GetAll());
        }
    }
}
