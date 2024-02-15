namespace SchoolBackend.Entities.Models;
public sealed class StudentLesson
{
    public Guid StudentId { get; set; }
    public Student? Student { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
    public Guid LessonId { get; set; }
    public Lesson? Lesson { get; set; }
}
