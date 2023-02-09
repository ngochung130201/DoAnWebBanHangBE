using DoAnBE.Models;
using DoAnBE.Repository.member;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ComputerdbContext _context;
        private readonly IMember _MemberRepo;

        public MembersController(IMember repo, ComputerdbContext context)

        {
            _context = context;
            _MemberRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMember()
        {
            var result = await _MemberRepo.GetAllMemberAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdMember(Guid id)
        {
            var Member = await _MemberRepo.GetMemberAsync(id);
            return Member == null ? NotFound() : Ok(Member);


        }
        [HttpPost]
        public async Task<IActionResult> AddMember(MemberModel Member)
        {
            try
            {
                var result = await _MemberRepo.AddMemberAsync(Member);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveMember(Guid id)
        {
            try
            {
                await _MemberRepo.RemoveMemberAsync(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(Guid id, MemberModel Member)
        {
            if (id != Member.ID)
            {
                return NotFound();
            }
            await _MemberRepo.UpdateMemberAsync(id, Member);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveMember(List<MemberModel> Members)
        {
            var listMember = await _context.Members.ToListAsync();
            await _MemberRepo.RemoveMemberAllAsync(Members);
            return Ok(Members);
        }

    }
}
