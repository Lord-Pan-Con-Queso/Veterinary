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
    public class SelectClientQuery : IRequest<PaginatedResponse<IEnumerable<ClientFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public bool IsDeleted { get; set; }
        public class SelectClientQueryHandler : IRequestHandler<SelectClientQuery, PaginatedResponse<IEnumerable<ClientFullDto>>>
        {
            private readonly IRepositoryCustom<Client> _repository;
            private readonly IMapper _mapper;

            public SelectClientQueryHandler(IRepositoryCustom<Client> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<ClientFullDto>>> Handle(SelectClientQuery request, CancellationToken cancellationToken)
            {
                ClientResponseFilter responseFilter = new ClientResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    clientName = request.clientName,
                    clientSurname = request.clientSurname,
                    IsDeleted = request.IsDeleted,
                };

                var clients = await _repository.ListAsync(new PaginatedClientSpecification(responseFilter));
                var clientFullDtos = _mapper.Map<IEnumerable<ClientFullDto>>(clients);
                return new PaginatedResponse<IEnumerable<ClientFullDto>>(clientFullDtos, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}
