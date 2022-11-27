using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface ITeamInfoService
    {
        public Task<List<MemberInfoDTO>> GetMembersInfo();

        public Task<MemberInfoDTO> GetMember(int ID);

        public Task<bool> AddMemberInfo(int ID, MemberInfoDTO info);

        public Task<TeamInfo> UpdateInfo(MemberInfoDTO member, int ID);

        public Task<string> DeleteMemberInfo(int ID);
    }
}
