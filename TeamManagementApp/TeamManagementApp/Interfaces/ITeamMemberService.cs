using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface ITeamMemberService
    {
        public Task<List<MemberBasicDataDTO>> GetMembers();

        public Task<TeamMember> GetMember(int ID);
        public Task<bool> AddMember(MemberBasicDataDTO member);

        public Task<string> DeleteMember(int ID);

        public Task<TeamMember> UpdateMember(MemberBasicDataDTO member);

    }
}
