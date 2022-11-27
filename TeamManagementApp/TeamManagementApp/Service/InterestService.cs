using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Service
{
    public class InterestService : IInterestService
    {

        private readonly IInterestRepository _interestRepository;
        private readonly IMapper _mapper;
        public Task<bool> AddInterest(int ID, InterestDTO interest)
        {
            Interest memberInterst = _mapper.Map<Interest>(interest);
            return _interestRepository.AddInterest(ID, memberInterst);
        }

        public Task<string> DeleteMembersInterest(int ID)
        {
            return _interestRepository.DeleteMembersInterest(ID);
        }

        public Task<InterestDTO> GetMemberInterest(int ID)
        {
            return _interestRepository.GetMemberInterest(ID);
        }

        public Task<List<InterestDTO>> GetMembersInterests()
        {
            return _interestRepository.GetMembersInterests();
        }
        public Task<Interest> UpdateInterest(InterestDTO interest, int ID)
        {
            Interest memberInterst = _mapper.Map<Interest>(interest);
            return _interestRepository.UpdateInterest(memberInterst, ID);
        }

    }
}
