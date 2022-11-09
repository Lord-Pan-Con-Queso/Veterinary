using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateClientCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string clientName { get; set; }
        public string clientSurname { get; set; }
        public string clientAdress { get; set; }
        public string clientPhoneNum { get; set; }
        public string clientIdn { get; set; }
        public string clientEmail { get; set; }
    }
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<long>>
    {
        private readonly IRepositoryCustom<Client> _repository;


        public UpdateClientCommandHandler(IRepositoryCustom<Client> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
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
                register.clientName = request.clientName;
                register.clientSurname = request.clientSurname;
                register.clientAdress = request.clientAdress;
                register.clientPhoneNum = request.clientPhoneNum;
                register.clientIdn = request.clientIdn;
                register.clientEmail = request.clientEmail;


                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}
