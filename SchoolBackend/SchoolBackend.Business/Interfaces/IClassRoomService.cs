using SchoolBackend.Entities.DTOs;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.Business.Interfaces;
public interface IClassRoomService
{
    string Create(CreateClassRoomDto request);
    string Update(UpdateClassRoomDto request);
    string DeleteById(Guid id);
    List<ClassRoom> GetAll();
}
