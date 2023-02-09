using AutoMapper;
using DoAnBE.Models;
using DoAnBE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnBE.Repository.member
{
    public class MemberRes : IMember

    {
        private readonly ComputerdbContext _context;
        private IMapper _mapper;
        public MemberRes(ComputerdbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Guid> AddMemberAsync(MemberModel Member)
        {
            var newMember = _mapper.Map<Member>(Member);
            _context.Members.Add(newMember);
            await _context.SaveChangesAsync();
            return newMember.ID;
        }

        public async Task<List<MemberModel>> GetAllMemberAsync()
        {
            var MemberList = await _context.Members.ToListAsync();
            return _mapper.Map<List<MemberModel>>(MemberList);
        }

        public async Task<MemberModel> GetMemberAsync(Guid id)
        {
            var resultDetailMember = await _context.Members.FindAsync(id);
            return _mapper.Map<MemberModel>(resultDetailMember);
        }


        public async Task RemoveMemberAllAsync(List<MemberModel> Member)
        {
            foreach (var item in Member)
            {
                RemoveMemberAsync(item.ID);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveMemberAsync(Guid id)
        {
            if (id != null)
            {
                var getMember = await _context.Members.FindAsync(id);
                if (getMember != null)
                {
                    _context.Members.Remove(getMember);
                    await _context.SaveChangesAsync();

                }
            }
        }
        public async Task UpdateMemberAsync(Guid id, MemberModel Member)
        {

            if (id == Member.ID)
            {
                var updateMember = _mapper.Map<Member>(Member);
                _context.Members!.Update(updateMember);
                await _context.SaveChangesAsync();
            }

        }


    }
}
