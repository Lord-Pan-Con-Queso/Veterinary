using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreateUserRolCommand : IRequest<Response<long>>
    {
        public string rol { get; set; }

    }
    public class CreateUserRolCommandHandler : IRequestHandler<CreateUserRolCommand, Response<long>>
    {
        private readonly IRepositoryCustom<UserRol> _repository;
        private readonly IMapper _mapper;

        public CreateUserRolCommandHandler(IRepositoryCustom<UserRol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateUserRolCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<UserRol>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}