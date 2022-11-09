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
    public class SelectUserRolQuery : IRequest<PaginatedResponse<IEnumerable<UserRolFullDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? rol { get; set; }
        public bool IsDeleted { get; set; }


        public class SelectUserRolQueryHandler : IRequestHandler<SelectUserRolQuery, PaginatedResponse<IEnumerable<UserRolFullDto>>>
        {
            private readonly IRepositoryCustom<UserRol> _repository;
            private readonly IMapper _mapper;

            public SelectUserRolQueryHandler(IRepositoryCustom<UserRol> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginatedResponse<IEnumerable<UserRolFullDto>>> Handle(SelectUserRolQuery request, CancellationToken cancellationToken)
            {
                UserRolResponseFilter responseFilter = new UserRolResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    rol = request.rol,
                    IsDeleted = request.IsDeleted
                };

                var userRol = await _repository.ListAsync(new PaginatedUserRolSpecification(responseFilter));
                var userRolFullDtos = _mapper.Map<IEnumerable<UserRolFullDto>>(userRol);
                return new PaginatedResponse<IEnumerable<UserRolFullDto>>(userRolFullDtos, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}