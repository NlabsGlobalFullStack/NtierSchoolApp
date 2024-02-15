namespace SchoolBackend.Entities.DTOs;
public sealed record UpdateStudentDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public Guid ClassRoomId { get; set; }
}
