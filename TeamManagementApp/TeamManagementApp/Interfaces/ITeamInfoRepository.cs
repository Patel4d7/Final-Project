using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface ITeamInfoRepository
    {
        public Task<List<MemberInfoDTO>> GetMembersInfo();

        public Task<MemberInfoDTO> GetMemberInfo(int ID);

        public Task<bool> AddMemberInfo(int ID, TeamInfo info);

        public Task<TeamInfo> UpdateInfo(TeamInfo memberInfo, int ID);

        public Task<string> DeleteMemberInfo(int ID);
    }
}
