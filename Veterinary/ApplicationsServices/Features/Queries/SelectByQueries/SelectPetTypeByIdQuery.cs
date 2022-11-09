using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectPetTypeByIdQuery : IRequest<Response<PetTypeFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectPetTypeByIdQueryHandler : IRequestHandler<SelectPetTypeByIdQuery, Response<PetTypeFullDto>>
    {
        private readonly IRepositoryCustom<PetType> _repository;
        private readonly IMapper _mapper;

        public SelectPetTypeByIdQueryHandler(IRepositoryCustom<PetType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<PetTypeFullDto>> IRequestHandler<SelectPetTypeByIdQuery, Response<PetTypeFullDto>>.Handle(SelectPetTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var petType = await _repository.GetByIdAsync(request.Id);
            if (petType == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<PetTypeFullDto>(petType);
                return new Response<PetTypeFullDto>(dto);

            }
        }
    }

}