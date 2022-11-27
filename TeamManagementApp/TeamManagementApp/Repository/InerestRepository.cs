using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManagementApp.Database;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repository
{
    public class InterestRepository : IInterestRepository
    {

        private readonly DataContext _context;

        public InterestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<InterestDTO>> GetMembersInterests()
        {
            var data = (from interest in _context.Interests
                        join member in _context.TeamMembers
                        on interest.TeamMembers.ID equals member.ID
                        select new InterestDTO
                        {
                            Name = member.FirstName + " " + member.LastName,
                            FavoriteDish = interest.FavoriteDish,
                            Skills = interest.Skills,
                            Hobby1 = interest.Hobby1,
                            Hobby2 = interest.Hobby2
                        }).ToList();
            return data;
        }

        public async Task<InterestDTO> GetMemberInterest(int ID)
        {
            //var result = _context.TeamInfos.Where(thisMember => thisMember.ID == ID).FirstOrDefault();

            var data = from interest in _context.Interests
                       join member in _context.TeamMembers
                       on interest.TeamMembers.ID equals member.ID
                       where interest.TeamMembers.ID == ID
                       select new InterestDTO
                       {
                           Name = member.FirstName + " " + member.LastName,
                           FavoriteDish = interest.FavoriteDish,
                           Skills = interest.Skills,
                           Hobby1 = interest.Hobby1,
                           Hobby2 = interest.Hobby2
                       };

            return (InterestDTO)data;
        }

        public async Task<bool> AddInterest(int ID, Interest interest)
        {
            interest.TeamMembers = await _context.TeamMembers.FindAsync(ID);
            await _context.Interests.AddAsync(interest);

            var result = _context.SaveChangesAsync();

            if (await result == 0)
                return false;
            return true;
        }

        public async Task<Interest> UpdateInterest(Interest interest, int ID)
        {
            var memberInfoExist = _context.Interests.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                memberInfoExist.FavoriteDish = interest.FavoriteDish;
                memberInfoExist.Skills = interest.Skills;
                memberInfoExist.Hobby1 = interest.Hobby1;
                memberInfoExist.Hobby2 = interest.Hobby2;

                await _context.SaveChangesAsync();
                return memberInfoExist;
            }
            return null;
        }

        public async Task<string> DeleteMembersInterest(int ID)
        {
            var memberInfoExist = _context.Interests.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                _context.Interests.Remove(memberInfoExist);
                await _context.SaveChangesAsync();
                return "Member's Interests Removed";
            }

            return "Member's Interests info Doesn't exist";
        }
    }
}
