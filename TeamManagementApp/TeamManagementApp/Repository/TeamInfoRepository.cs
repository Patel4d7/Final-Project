using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManagementApp.Database;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repository
{
    public class TeamInfoRepository : ITeamInfoRepository
    {
        private readonly DataContext _context;
        public TeamInfoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MemberInfoDTO>> GetMembersInfo()
        {
            var data = (from info in _context.TeamInfos
                        join member in _context.TeamMembers
                        on info.TeamMembers.ID equals member.ID
                        select new MemberInfoDTO
                        {
                            Name = member.FirstName + " " + member.LastName,
                            College = info.College,
                            CollegeEmail = info.CollegeEmail,
                            CollegeProgram = info.CollegeProgram,
                            YearInProgram = info.YearInProgram
                        }).ToList();
            return data;
        }

        public async Task<MemberInfoDTO> GetMemberInfo(int ID)
        {
            //var result = _context.TeamInfos.Where(thisMember => thisMember.ID == ID).FirstOrDefault();

            var data = from info in _context.TeamInfos
                       join member in _context.TeamMembers
                       on info.TeamMembers.ID equals member.ID
                       where info.TeamMembers.ID == ID
                       select new MemberInfoDTO
                       {
                           Name = member.FirstName + " " + member.LastName,
                           College = info.College,
                           CollegeEmail = info.CollegeEmail,
                           CollegeProgram = info.CollegeProgram,
                           YearInProgram = info.YearInProgram
                       };

            return (MemberInfoDTO)data;
        }

        public async Task<bool> AddMemberInfo(int ID, TeamInfo info)
        {
            info.TeamMembers = await _context.TeamMembers.FindAsync(ID);
            await _context.TeamInfos.AddAsync(info);

            var result = _context.SaveChangesAsync();

            if (await result == 0)
                return false;
            return true;
        }

        public async Task<TeamInfo> UpdateInfo(TeamInfo memberInfo, int ID)
        {
            var memberInfoExist = _context.TeamInfos.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                memberInfoExist.College = memberInfo.College;
                memberInfoExist.CollegeEmail = memberInfo.CollegeEmail;
                memberInfoExist.CollegeProgram = memberInfo.CollegeProgram;
                memberInfoExist.YearInProgram = memberInfo.YearInProgram;

                await _context.SaveChangesAsync();
                return memberInfoExist;
            }
            return null;
        }

        public async Task<string> DeleteMemberInfo(int ID)
        {
            var memberInfoExist = _context.TeamInfos.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                _context.TeamInfos.Remove(memberInfoExist);
                await _context.SaveChangesAsync();
                return "Member Removed";
            }

            return "Member info Doesn't exist";
        }
    }
}
