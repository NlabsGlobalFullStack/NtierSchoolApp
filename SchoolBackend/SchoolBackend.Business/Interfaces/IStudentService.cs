using SchoolBackend.Entities.DTOs;
using SchoolBackend.Entities.Models;

namespace SchoolBackend.Business.Interfaces;
public interface IStudentService
{
    string Create(CreateStudentDto request);
    string Update(UpdateStudentDto request);
    string DeleteById(Guid id);
    List<Student> GetAll();
    List<Student> GetAllByClassRoomId(Guid classRoomId);
}
