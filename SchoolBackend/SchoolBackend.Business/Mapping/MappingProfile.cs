using AutoMapper;
using SchoolBackend.Entities.DTOs;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.Business.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();

        CreateMap<CreateClassRoomDto, ClassRoom>();
        CreateMap<UpdateClassRoomDto, ClassRoom>();
    }
}
