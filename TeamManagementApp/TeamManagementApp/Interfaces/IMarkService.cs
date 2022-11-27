using System.Collections.Generic;
using System.Threading.Tasks;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp.Interfaces
{
    public interface IMarkService
    {
        public Task<List<MarksDTO>> GetMarks();

        public Task<MarksDTO> GetMemberMarks(int ID);

        public Task<bool> AddMarks(int ID, MarksDTO marks);
        public Task<Mark> UpdateMarks(MarksDTO memberMarks, int ID);

        public Task<string> DeleteMarks(int ID);
    }
}
