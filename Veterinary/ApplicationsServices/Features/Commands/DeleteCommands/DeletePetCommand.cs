using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.DeleteCommands
{
    public class DeletePetCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeletePetCommandHandle : IRequestHandler<DeletePetCommand, Response<long>>
    {
        private readonly IRepositoryCustom<Pet> _repository;

        public DeletePetCommandHandle(IRepositoryCustom<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletePetCommand request, CancellationToken cancellationToken)
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
