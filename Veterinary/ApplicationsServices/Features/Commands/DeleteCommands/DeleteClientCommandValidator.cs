using FluentValidation;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
        {
            public DeleteClientCommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty().NotNull();
            }
        }
}
