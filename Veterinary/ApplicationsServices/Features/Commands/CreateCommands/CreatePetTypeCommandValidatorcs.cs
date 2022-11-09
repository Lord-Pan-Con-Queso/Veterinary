using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreatePetTypeCommandValidator : AbstractValidator<CreatePetTypeCommand>
    {
        public CreatePetTypeCommandValidator()
        {
            RuleFor(x => x.type)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
        }
    }
}