using FluentValidation;
using SchoolBackend.Entities.DTOs;

namespace SchoolBackend.DataAccess.Validators;
public sealed class CreateClassRoomDtoValidator : AbstractValidator<CreateClassRoomDto>
{
    public CreateClassRoomDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
    }
}
