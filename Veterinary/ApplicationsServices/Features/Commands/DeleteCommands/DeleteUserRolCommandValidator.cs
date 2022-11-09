using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using FluentValidation;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeleteUserRolCommandValidator : AbstractValidator<DeleteUserRolCommand>
    {
        public DeleteUserRolCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
        }
    }
}