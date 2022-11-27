using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Service
{
    public class TeamInfoService : ITeamInfoService
    {
        private readonly ITeamInfoRepository _teamInfoRepository;
        private readonly IMapper _mapper;
        public TeamInfoService(ITeamInfoRepository teamInfoRepository, IMapper mapper)
        {
            _mapper = mapper;
            _teamInfoRepository = teamInfoRepository;
        }
        public Task<bool> AddMemberInfo(int ID, MemberInfoDTO info)
        {
            TeamInfo teamInfo = _mapper.Map<TeamInfo>(info);
            return _teamInfoRepository.AddMemberInfo(ID, teamInfo);
        }

        public Task<string> DeleteMemberInfo(int ID)
        {
            return _teamInfoRepository.DeleteMemberInfo(ID);
        }

        public Task<MemberInfoDTO> GetMember(int ID)
        {
            return _teamInfoRepository.GetMemberInfo(ID);
        }

        public Task<List<MemberInfoDTO>> GetMembersInfo()
        {
            return _teamInfoRepository.GetMembersInfo();
        }

        public Task<TeamInfo> UpdateInfo(MemberInfoDTO info, int ID)
        {
            TeamInfo teamInfo = _mapper.Map<TeamInfo>(info);
            return _teamInfoRepository.UpdateInfo(teamInfo, ID);
        }
    }
}
