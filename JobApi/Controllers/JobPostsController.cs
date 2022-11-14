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
        public async Task<ActionResult<List<JobPost>>> Get()
        {
            var data =  await _repository.GetAllJobPost();
            if (data == null)
                return NotFound();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<JobPostGetDTO>> GetJobPost(int id)
        {
            var jobPost = await _repository.GetByIdJobPost(id);

            if (jobPost == null)
            {
                return NotFound();
            }

            return Ok(jobPost);
        }
        [HttpPost]
        public async Task<ActionResult<JobPostDTO>> Add(JobPostDTO jobpost)
        {
            await _repository.CreateJobPost(jobpost);
            return Ok(_repository.GetAll());
        }
        [HttpPut] 
        public async Task<ActionResult<JobPostDTO>> Update(JobPostDTO jobpost)
        {
            await _repository.Update(jobpost);

        }
    }
}
