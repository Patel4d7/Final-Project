using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface IMarkRepository
    {
        public Task<List<MarksDTO>> GetMarks();

        public  Task<MarksDTO> GetMemberMarks(int ID);

        public  Task<bool> AddMarks(int ID, Mark marks);
        public  Task<Mark> UpdateMarks(Mark memberInfo, int ID);

        public  Task<string> DeleteMarks(int ID);
    }
}
