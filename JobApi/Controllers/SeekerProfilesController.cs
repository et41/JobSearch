using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApi.DataAccess;
using JobApi.Models;
using JobApi.Models.DTOS.SeekerDTOS;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AutoMapper;

namespace JobApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeekerProfilesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SeekerProfilesController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/SeekerProfiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeekerProfile>>> GetSeekerProfiles()
        {
            return await _context.SeekerProfiles.ToListAsync();
        }

        // GET: api/SeekerProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeekerProfile>> GetSeekerProfile(int id)
        {
            var seekerProfile = await _context.SeekerProfiles.FindAsync(id);

            if (seekerProfile == null)
            {
                return NotFound();
            }

            return seekerProfile;
        }

        // PUT: api/SeekerProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeekerProfile(int id, SeekerProfile seekerProfile)
        {
            if (id != seekerProfile.SeekerProfileId)
            {
                return BadRequest();
            }

            _context.Entry(seekerProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeekerProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<SeekerProfile>> PostSeekerProfile(SeekerProfilePostDTO seekerProfile)
        {
            SeekerProfile mappedProfile = new SeekerProfile()
            {
                FirstName = seekerProfile.FirstName,
                LastName = seekerProfile.LastName,
                SeekerExperienceDetail = _mapper.Map<SeekerExperienceDetail>(seekerProfile.SeekerExperienceDetail),
                SeekerEducationDetail = _mapper.Map<SeekerEducationDetail>(seekerProfile.SeekerEducationDetail),
                SeekerSkills = _mapper.Map<ICollection<SeekerSkill>>(seekerProfile.SeekerSkills),
            };
            await _context.Set<SeekerProfile>().AddAsync(mappedProfile);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/SeekerProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeekerProfile(int id)
        {
            var seekerProfile = await _context.SeekerProfiles.FindAsync(id);
            if (seekerProfile == null)
            {
                return NotFound();
            }

            _context.SeekerProfiles.Remove(seekerProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeekerProfileExists(int id)
        {
            return _context.SeekerProfiles.Any(e => e.SeekerProfileId == id);
        }
    }
}
