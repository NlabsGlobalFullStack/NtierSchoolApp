using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class Lesson : Entity
{
    public string Name { get; set; } = string.Empty;
}
