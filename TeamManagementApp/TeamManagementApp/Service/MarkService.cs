using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using TeamManagementApp.DTOs;
using TeamManagementApp.Interfaces;
using TeamManagementApp.Models;

namespace TeamManagementApp.Service
{
    public class MarkService : IMarkService
    {
        private readonly IMarkRepository _markRepository;
        private readonly IMapper _mapper;

        public MarkService(IMarkRepository markRepository, IMapper mapper)
        {
            _markRepository = markRepository;
            _mapper = mapper;
        }

        public Task<bool> AddMarks(int ID, MarksDTO marks)
        {
            Mark mark = _mapper.Map<Mark>(marks);
            return _markRepository.AddMarks(ID, mark);
        }

        public Task<string> DeleteMarks(int ID)
        {
            return _markRepository.DeleteMarks(ID);
        }

        public Task<List<MarksDTO>> GetMarks()
        {
            return _markRepository.GetMarks();
        }

        public Task<MarksDTO> GetMemberMarks(int ID)
        {
            return _markRepository.GetMemberMarks(ID);
        }
        public Task<Mark> UpdateMarks(MarksDTO memberMarks, int ID)
        {
            Mark mark = _mapper.Map<Mark>(memberMarks);
            return _markRepository.UpdateMarks(mark, ID);
        }

    }
}
