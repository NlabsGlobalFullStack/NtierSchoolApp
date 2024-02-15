using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class ClassRoom : Entity
{
    public string Name { get; set; } = string.Empty;
}
