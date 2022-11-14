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
        public async Task<List<JobPost>> Get()
        {
            var data =  _repository.GetAllJobPost();
            return await data;
        }
        [HttpPost]
        public async Task<ActionResult<JobPostDTO>> Add(JobPostDTO jobpost)
        {
            await _repository.CreateJobPost(jobpost);
            return Ok(_repository.GetAll());
        }
        /*
        [HttpPost]
        public async Task<ActionResult<JobPostDTO>> Add(JobPostDTO jobpost)
        {
            await _repository.CreateJobPostWithDto(jobpost);
            return Ok(_repository.GetAll());
        }
        */
    }
}
