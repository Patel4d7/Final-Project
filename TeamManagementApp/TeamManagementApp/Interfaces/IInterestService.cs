using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface IInterestService
    {
        public Task<List<InterestDTO>> GetMembersInterests();

        public Task<InterestDTO> GetMemberInterest(int ID);

        public Task<bool> AddInterest(int ID, InterestDTO marks);

        public Task<Interest> UpdateInterest(InterestDTO interest, int ID);

        public Task<string> DeleteMembersInterest(int ID);
    }
}
