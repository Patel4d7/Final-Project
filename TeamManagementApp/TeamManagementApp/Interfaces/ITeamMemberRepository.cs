using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface ITeamMemberRepository
    {
        public Task<List<MemberBasicDataDTO>> GetMembers();

        public Task<TeamMember> GetMember(int ID);
        public Task<bool> AddMember(TeamMember member);

        public Task<string> DeleteMember(int ID);

        public Task<TeamMember> UpdateMember(TeamMember member);
    }
}
