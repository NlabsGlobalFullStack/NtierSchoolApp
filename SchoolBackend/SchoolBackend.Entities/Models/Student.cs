using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class Student : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", this.FirstName, this.LastName);
    public byte ClassNumber { get; set; } = 0;
    public int StudentNumber { get; set; } = 0;
    public string IdentityNumber { get; set; } = string.Empty;
    public byte Age { get; set; } = 7;
    public Guid ClassRoomId { get; set; }
    public ClassRoom? ClassRoom { get; set; }
}
