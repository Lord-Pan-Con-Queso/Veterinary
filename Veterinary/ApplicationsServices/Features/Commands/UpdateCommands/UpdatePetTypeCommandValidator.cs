using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePetTypeCommandValidator : AbstractValidator<UpdatePetTypeCommand>
    {
        public UpdatePetTypeCommandValidator()
        {
            RuleFor(x => x.type)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}