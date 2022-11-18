using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobApi.DataAccess;
using JobApi.Models.UserAccountModels;
using JobApi.Models.DTOS.UserAccountDTOS;
using AutoMapper;

namespace JobApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserAccountsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserAccountsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Route("user/seeker")]
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccountSeeker(UserAccountSeekerDTO userAccount)
        {
            var newSeekerUser = _mapper.Map<UserAccount>(userAccount);
            _context.UserAccount.Add(_mapper.Map<UserAccount>(userAccount));
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("user/company")]
        [HttpPost]
        public async Task<ActionResult<UserAccount>> PostUserAccountCompany(UserAccountCompanyDTO userAccount)
        {
            var newSeekerUser = _mapper.Map<UserAccount>(userAccount);
            _context.UserAccount.Add(_mapper.Map<UserAccount>(userAccount));
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
