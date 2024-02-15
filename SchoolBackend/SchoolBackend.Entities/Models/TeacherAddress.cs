using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class TeacherAddress : Entity
{
    public Guid TeacherId { get; set; }
    public bool IsMainAddress { get; set; } = false;
    public string Address { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
