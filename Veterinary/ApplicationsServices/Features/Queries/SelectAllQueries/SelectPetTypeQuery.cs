using ApplicationsServices.Filters;
using ApplicationsServices.Interfaces;
using ApplicationsServices.Specifications;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectAllQueries
{
    public class SelectPetTypeQuery : IRequest<PaginatedResponse<IEnumerable<PetTypeFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? type { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SelectPetTypeQueryHandler : IRequestHandler<SelectPetTypeQuery, PaginatedResponse<IEnumerable<PetTypeFullDto>>>
    {
        private readonly IRepositoryCustom<PetType> _repository;
        private readonly IMapper _mapper;

        public SelectPetTypeQueryHandler(IRepositoryCustom<PetType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginatedResponse<IEnumerable<PetTypeFullDto>>> Handle(SelectPetTypeQuery request, CancellationToken cancellationToken)
        {
            PetTypeResponseFilter responseFilter = new PetTypeResponseFilter()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                type = request.type,
                IsDeleted = request.IsDeleted
            };

            var type = await _repository.ListAsync(new PaginatedPetTypeSpecification(responseFilter));
            var petTypeFullDtos = _mapper.Map<IEnumerable<PetTypeFullDto>>(type);
            return new PaginatedResponse<IEnumerable<PetTypeFullDto>>(petTypeFullDtos, request.PageNumber, request.PageSize, request.IsDeleted);
        }
    }
}