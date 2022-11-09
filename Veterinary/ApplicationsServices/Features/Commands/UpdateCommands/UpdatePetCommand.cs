using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePetCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long petTypeId { get; set; }
    }
    public class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Response<long>>
    {
        private readonly IRepositoryCustom<Pet> _repository;


        public UpdatePetCommandHandler(IRepositoryCustom<Pet> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
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
                register.Id = request.Id;
                register.petName = request.petName;
                register.clientId = request.clientId;
                register.petTypeId = request.petTypeId;

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
