using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreatePetCommand : IRequest<Response<long>>
    {
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long petTypeId { get; set; }
    }
    public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Response<long>>
    {
        private readonly IRepositoryCustom<Pet> _repository;
        private readonly IMapper _mapper;

        public CreatePetCommandHandler(IRepositoryCustom<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreatePetCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<Pet>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}

