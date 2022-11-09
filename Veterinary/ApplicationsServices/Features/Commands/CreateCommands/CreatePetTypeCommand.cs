using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Commands.CreateCommands
{
    public class CreatePetTypeCommand : IRequest<Response<long>>
    {
        public string? type { get; set; }
    }
    public class CreatePetTypeCommandHandler : IRequestHandler<CreatePetTypeCommand, Response<long>>
    {
        private readonly IRepositoryCustom<PetType> _repository;
        private readonly IMapper _mapper;

        public CreatePetTypeCommandHandler(IRepositoryCustom<PetType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreatePetTypeCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<PetType>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}

