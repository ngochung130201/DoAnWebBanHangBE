using DoAnBE.ViewModels;

namespace DoAnBE.Repository.member
{
    public interface IMember
    {
        public Task<List<MemberModel>> GetAllMemberAsync();
        public Task<Guid> AddMemberAsync(MemberModel Member);
        public Task<MemberModel> GetMemberAsync(Guid id);
        public Task UpdateMemberAsync(Guid id, MemberModel Member);
        public Task RemoveMemberAsync(Guid id);
        public Task RemoveMemberAllAsync(List<MemberModel> Member);
    }
}
