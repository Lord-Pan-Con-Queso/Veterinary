using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectPetByIdQuery : IRequest<Response<PetFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectPetByIdQueryHandler : IRequestHandler<SelectPetByIdQuery, Response<PetFullDto>>
    {
        private readonly IRepositoryCustom<Pet> _repository;
        private readonly IMapper _mapper;

        public SelectPetByIdQueryHandler(IRepositoryCustom<Pet> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<PetFullDto>> IRequestHandler<SelectPetByIdQuery, Response<PetFullDto>>.Handle(SelectPetByIdQuery request, CancellationToken cancellationToken)
        {
            var pet = await _repository.GetByIdAsync(request.Id);
            if (pet == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<PetFullDto>(pet);
                return new Response<PetFullDto>(dto);

            }
        }
    }

}