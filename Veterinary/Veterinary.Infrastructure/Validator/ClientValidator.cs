//Paquete NuGet que valida los datos que van a la base de datos. Validaciones del lado del servidor.
using FluentValidation;
using Veterinary.Core.Entities;

namespace Veterinary.Infrastructure.Validator
{
    //Se valida con entidades, no con DTOs.
    public class ClientValidator : AbstractValidator<Client>
    {
        public ClientValidator()
        {
            //Se validan los datos aca en lugar de en las entidades.
            RuleFor(client => client.clientName)
                .NotNull()
                .MaximumLength(15);
            RuleFor(client => client.clientSurname)
                .NotNull()
                .MaximumLength(15);
        }
    }
}


