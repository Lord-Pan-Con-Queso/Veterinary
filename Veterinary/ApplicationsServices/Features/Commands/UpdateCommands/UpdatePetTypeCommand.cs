using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdatePetTypeCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string type { get; set; }
    }
    public class UpdatePetTypeCommandHandler : IRequestHandler<UpdatePetTypeCommand, Response<long>>
    {
        private readonly IRepositoryCustom<PetType> _repository;


        public UpdatePetTypeCommandHandler(IRepositoryCustom<PetType> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdatePetTypeCommand request, CancellationToken cancellationToken)
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
                register.type = request.type;
                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
