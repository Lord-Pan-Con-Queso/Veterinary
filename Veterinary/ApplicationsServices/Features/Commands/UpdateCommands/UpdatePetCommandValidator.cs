using FluentValidation;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePetCommandValidator : AbstractValidator<UpdatePetCommand>
    {
        public UpdatePetCommandValidator()
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