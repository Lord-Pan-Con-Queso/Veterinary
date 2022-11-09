using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeletePetTypeCommandValidator : AbstractValidator<DeletePetTypeCommand>
    {
        public DeletePetTypeCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}