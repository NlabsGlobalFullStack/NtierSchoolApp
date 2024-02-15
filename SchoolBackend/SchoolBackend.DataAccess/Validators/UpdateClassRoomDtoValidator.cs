using FluentValidation;
using SchoolBackend.Entities.DTOs;

namespace SchoolBackend.DataAccess.Validators;
public sealed class UpdateClassRoomDtoValidator : AbstractValidator<UpdateClassRoomDto>
{
    public UpdateClassRoomDtoValidator()
    {
        RuleFor(p => p.Id).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().MinimumLength(3);
    }
}
