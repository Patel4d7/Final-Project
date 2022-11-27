using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Service
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public Task<bool> AddMember(MemberBasicDataDTO member)
        {
            TeamMember teamMember = _mapper.Map<TeamMember>(member);
            return _teamMemberRepository.AddMember(teamMember);
        }

        public Task<string> DeleteMember(int ID)
        {
            return _teamMemberRepository.DeleteMember(ID);
        }

        public Task<TeamMember> GetMember(int ID)
        {
            return _teamMemberRepository.GetMember(ID);
        }

        public Task<List<MemberBasicDataDTO>> GetMembers()
        {
            return _teamMemberRepository.GetMembers();
        }

        public Task<TeamMember> UpdateMember(MemberBasicDataDTO member)
        {
            TeamMember teamMember = _mapper.Map<TeamMember>(member);
            return _teamMemberRepository.UpdateMember(teamMember);
        }
    }
}
