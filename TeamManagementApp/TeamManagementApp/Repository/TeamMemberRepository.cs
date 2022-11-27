using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManagementApp.Database;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repository
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private readonly DataContext _context;
        public TeamMemberRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<List<MemberBasicDataDTO>> GetMembers()
        {
            //var data = (from member in _context.TeamMembers
            //           join interest in _context.Interests
            //           on member.ID equals interest.TeamMembers.ID
            //           select new MemberDTO
            //           {
            //               FirstName = member.FirstName,
            //               LastName = member.LastName,
            //               DOB = (System.DateTime)member.DOB,
            //               Email = member.Email,
            //               Skills = interest.Skills,
            //               Hobby1 = interest.Hobby1,
            //               Hobby2 = interest.Hobby2,
            //               FavoriteDish = interest.FavoriteDish
            //           }).ToList();
            var data = (from member in _context.TeamMembers
                       select new MemberBasicDataDTO 
                       {
                           Id = member.ID,
                           FirstName = member.FirstName,
                           LastName = member.LastName,
                           DOB = (System.DateTime)member.DOB,
                           Email = member.Email,
                       }).ToList();
           return data;
        }
        public async Task<TeamMember> GetMember(int ID)
        {
            var result = _context.TeamMembers.Where(thisMember => thisMember.ID == ID).FirstOrDefault();

            return result;
        }

        public async Task<bool> AddMember(TeamMember member)
        {
            await _context.TeamMembers.AddAsync(member);

            var result = _context.SaveChangesAsync();

            if (await result == 0)
                return false;
            return true;        
        }

        public async Task<TeamMember> UpdateMember(TeamMember member)
        {
            var memberExist = await _context.TeamMembers.FindAsync(member.ID);

            if(memberExist != null)
            {
                memberExist.FirstName = member.FirstName;
                memberExist.LastName = member.LastName;
                memberExist.DOB = member.DOB;
                memberExist.Email = member.Email;

                await _context.SaveChangesAsync();
                return member;
            }
            return null;
        }

        public async Task<string> DeleteMember(int ID)
        {
            var member = await _context.TeamMembers.FindAsync(ID);

            if(member != null)
            {
                TeamInfo teamInfo = _context.TeamInfos.Where(thisMember => thisMember.TeamMembers.ID == ID).FirstOrDefault();
                if(teamInfo != null)
                {
                    _context.TeamInfos.Remove(teamInfo);
                }
                Interest interest = _context.Interests.Where(thisMember => thisMember.TeamMembers.ID == ID).FirstOrDefault();
                if(interest != null)
                {
                    _context.Interests.Remove(interest);
                }
                Mark mark = _context.Marks.Where(thisMember => thisMember.TeamMembers.ID == ID).FirstOrDefault();
                if(mark != null)
                {
                    _context.Marks.Remove(mark);
                }

                _context.TeamMembers.Remove(member);
                await _context.SaveChangesAsync();
                return "Member Removed";
            }

            return "Member doesn't exist";
        }
    }
}
