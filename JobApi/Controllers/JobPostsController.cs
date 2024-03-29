﻿using JobApi.DataAccess;
using JobApi.Models.DTOS.JobPostDTOS;
using JobApi.Models.JobPostModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobApi.Controllers
{
    [ApiController]
    [Route("/user/{userid}/[controller]")]
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
            return Ok(data);
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
        public async Task<ActionResult<JobPostDTO>> Add(JobPostDTO jobpost, int userid)
        {
            await _repository.CreateJobPost(jobpost, userid);
            return Ok(_repository.GetAll());
        }
        [HttpPut] 
        public async Task Update(JobPostGetDTO jobpost)
        {
            await _repository.UpdateJobPost(jobpost);
        }
        [HttpDelete("{id}")]
        public async Task DeleteJobPost(int id)
        {
             await _repository.Delete(id);
        }
    }
}
