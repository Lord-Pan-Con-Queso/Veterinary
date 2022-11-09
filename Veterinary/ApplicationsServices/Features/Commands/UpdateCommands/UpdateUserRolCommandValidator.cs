using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateUserRolCommandValidator : AbstractValidator<UpdateUserRolCommand>
    {
        public UpdateUserRolCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .NotNull().WithMessage("{PropertyName} no puede ser nulo.");
            RuleFor(x => x.rol)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");

        }
    }
}
