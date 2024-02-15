using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class ClassRoom : Entity
{
    public string Name { get; set; } = string.Empty;
    public List<Teacher>? Teachers { get; set; }
    public List<Lesson>? Lessons { get; set; }
    public List<Student>? Students { get; set; }
}
