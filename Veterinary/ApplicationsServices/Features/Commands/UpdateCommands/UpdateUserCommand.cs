using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.UpdateCommands
{
    public class UpdateUserCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string? userPhoneNum { get; set; }
        public long userRol { get; set; }
    }
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<long>>
    {
        private readonly IRepositoryCustom<User> _repository;


        public UpdateUserCommandHandler(IRepositoryCustom<User> repository, IMapper mapper)
        {
            _repository = repository;

        }

        public async Task<Response<long>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
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
                register.name = request.name;
                register.userSurname = request.userSurname;
                register.userName = request.userName;
                register.password = request.password;
                register.email = request.email;
                register.userPhoneNum = request.userPhoneNum;
                register.userRol = request.userRol;

                await _repository.UpdateAsync(register);
            }


            return new Response<long>(register.Id);
        }
    }
}

