using FluentValidation;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator()
        {
            RuleFor(x => x.petName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(30).WithMessage("{PropertyName} no debe exeder de {MaxLength} caracteres.");
            RuleFor(x => x.petTypeId)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
            RuleFor(x => x.clientId)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.");
        }
    }
}