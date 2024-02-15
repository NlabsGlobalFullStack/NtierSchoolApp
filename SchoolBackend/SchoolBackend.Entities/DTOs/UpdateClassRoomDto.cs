namespace SchoolBackend.Entities.DTOs;
public sealed record UpdateClassRoomDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
