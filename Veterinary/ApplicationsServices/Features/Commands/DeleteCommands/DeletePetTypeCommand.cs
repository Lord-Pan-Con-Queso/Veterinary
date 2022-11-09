using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeletePetTypeCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeletePetTypeCommandHandle : IRequestHandler<DeletePetTypeCommand, Response<long>>
    {
        private readonly IRepositoryCustom<PetType> _repository;

        public DeletePetTypeCommandHandle(IRepositoryCustom<PetType> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletePetTypeCommand request, CancellationToken cancellationToken)
        {
            //Obtiene el registro en base al Id enviado.
            var dltclient = await _repository.GetByIdAsync(request.Id);
            //Consulta si se regreso algún registro desde la base de datos.
            if (dltclient == null)
            {
                throw new KeyNotFoundException($"No se encontro el registro con el Id: {request.Id}");
            }
            else
            {

                dltclient.IsDeleted = true;
                await _repository.UpdateAsync(dltclient);
            }
            return new Response<long>(dltclient.Id);
        }
    }
}