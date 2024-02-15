namespace SchoolBackend.Entities.Models;
public sealed class StudentClassRoom
{
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
}
