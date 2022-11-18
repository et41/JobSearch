using AutoMapper;
using JobApi.DataAccess;
using JobApi.Models.DTOS.SeekerDTOS;
using JobApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace JobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekerProfileForCompanies : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SeekerProfileForCompanies(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeekerProfileGetDTO>>> GetSeekerProfiles()
        {
            var profiles = await _context.Set<SeekerProfile>()
                .Include(c => c.SeekerExperienceDetail)
                .Include(c => c.SeekerEducationDetail)
                .Include(c => c.SeekerSkills)
                .ToListAsync();
            return Ok(_mapper.Map<List<SeekerProfileGetDTO>>(profiles));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeekerProfileGetDTO>> GetSeekerProfile(int id)
        {
            var profile = await _context.Set<SeekerProfile>()
            .Include(c => c.SeekerExperienceDetail)
            .Include(c => c.SeekerEducationDetail)
            .Include(c => c.SeekerSkills)
            .FirstOrDefaultAsync(c => c.SeekerProfileId == id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SeekerProfileGetDTO>(profile));
        }

        [HttpGet("skill/{skill}")]
        public async Task<ActionResult<SeekerProfileGetDTO>> GetSeekerProfileBySkill(string skill)
        {
            var skillIds = _context.SeekerSkills.Where(s => s.SeekerSkillName == skill).Select(p => p.SeekerSkillId).ToList();
            List<SeekerProfile> profiles = new List<SeekerProfile>();
            foreach(var skillId in skillIds)
            {
                profiles.Add((from s in _context.SeekerProfiles
                           where s.SeekerSkills.Any(c => c.SeekerSkillId == skillId)
                           select s).Include(p => p.SeekerExperienceDetail).Include(p => p.SeekerEducationDetail)
                           .Include(p => p.SeekerSkills)
                           .First());

            }
            return Ok(profiles);
        }
        [HttpGet("education/{education}")]
        public async Task<ActionResult<SeekerProfileGetDTO>> GetSeekerProfileByEducation(string education)
        {
            var educationIds = await _context.SeekerEducationDetails.Where(p => p.UniversityName == education).Select(p => p.SeekerEducationDetailId).ToListAsync();
            List<SeekerProfile> profiles = new List<SeekerProfile>();
            foreach (var educationId in educationIds)
            {
                profiles.Add((from s in _context.SeekerProfiles
                              where s.SeekerEducationDetail.SeekerEducationDetailId == educationId
                              select s).Include(p => p.SeekerExperienceDetail).Include(p => p.SeekerEducationDetail)
                              .First());

            }
            return Ok(profiles);
        }
    }
}
