using SchoolBackend.Entities.Abstractions;

namespace SchoolBackend.Entities.Models;
public sealed class Teacher : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set;} = string.Empty;
    public string IdCardNumber { get; set; } = string.Empty;
    public bool IsMarried { get; set; } = false;
    public bool Gender { get; set; } = false;
    public byte Age { get; set; } = 22;
}
