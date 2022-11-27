using AutoMapper;
using TeamManagementApp.DTOs;
using TeamManagementApp.Models;

namespace TeamManagementApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TeamMember, MemberBasicDataDTO>().ReverseMap();
            CreateMap<TeamInfo, MemberInfoDTO>().ReverseMap();
            CreateMap<Mark, MarksDTO>().ReverseMap();
            CreateMap<Interest, InterestDTO>().ReverseMap();
        }
    }
}
