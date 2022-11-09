using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateUserRolCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string rol { get; set; }

    }
    public class UpdateUserRolCommandHandler : IRequestHandler<UpdateUserRolCommand, Response<long>>
    {
        private readonly IRepositoryCustom<UserRol> _repository;


        public UpdateUserRolCommandHandler(IRepositoryCustom<UserRol> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateUserRolCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var register = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (register == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
            }
            else
            {
                register.rol = request.rol;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}