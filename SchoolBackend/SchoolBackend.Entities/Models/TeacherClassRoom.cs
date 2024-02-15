namespace SchoolBackend.Entities.Models;
public sealed class TeacherClassRoom
{
    public Guid TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
}
