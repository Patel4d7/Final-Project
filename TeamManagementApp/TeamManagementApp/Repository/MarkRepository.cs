using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamManagementApp.Database;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Repository
{
    public class MarkRepository : IMarkRepository
    {
        private readonly DataContext _context;
        public MarkRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<MarksDTO>> GetMarks()
        {
            var data = (from marks in _context.Marks
                        join member in _context.TeamMembers
                        on marks.TeamMembers.ID equals member.ID
                        select new MarksDTO
                        {
                            Name = member.FirstName + " " + member.LastName,
                            DataStructure = marks.DataStructure,
                            NanoMechanics = marks.NanoMechanics,
                            DBMS = marks.DBMS,
                            Java = marks.Java
                        }).ToList();
            return data;
        }

        public async Task<MarksDTO> GetMemberMarks(int ID)
        {
            //var result = _context.TeamInfos.Where(thisMember => thisMember.ID == ID).FirstOrDefault();

            var data = from marks in _context.Marks
                       join member in _context.TeamMembers
                       on marks.TeamMembers.ID equals member.ID
                       where marks.TeamMembers.ID == ID
                       select new MarksDTO
                       {
                           Name = member.FirstName + " " + member.LastName,
                           DataStructure = marks.DataStructure,
                           NanoMechanics = marks.NanoMechanics,
                           DBMS = marks.DBMS,
                           Java = marks.Java
                       };

            return (MarksDTO)data;
        }

        public async Task<bool> AddMarks(int ID, Mark marks)
        {
            marks.TeamMembers = await _context.TeamMembers.FindAsync(ID);
            await _context.Marks.AddAsync(marks);

            var result = _context.SaveChangesAsync();

            if (await result == 0)
                return false;
            return true;
        }

        public async Task<Mark> UpdateMarks(Mark memberInfo, int ID)
        {
            var memberInfoExist = _context.Marks.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                memberInfoExist.DataStructure = memberInfo.DataStructure;
                memberInfoExist.NanoMechanics = memberInfo.NanoMechanics;
                memberInfoExist.Java = memberInfo.Java;
                memberInfoExist.DBMS = memberInfo.DBMS;

                await _context.SaveChangesAsync();
                return memberInfoExist;
            }
            return null;
        }

        public async Task<string> DeleteMarks(int ID)
        {
            var memberInfoExist = _context.Marks.Where(thisMemberInfo => thisMemberInfo.TeamMembers.ID == ID).FirstOrDefault();

            if (memberInfoExist != null)
            {
                _context.Marks.Remove(memberInfoExist);
                await _context.SaveChangesAsync();
                return "Member's Marks Removed";
            }

            return "Member's Marks info Doesn't exist";
        }
    }
}
