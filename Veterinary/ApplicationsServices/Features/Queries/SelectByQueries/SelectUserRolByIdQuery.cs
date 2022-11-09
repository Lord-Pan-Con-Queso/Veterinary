using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectUserRolByIdQuery : IRequest<Response<UserRolFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectUserRolByIdQueryHandler : IRequestHandler<SelectUserRolByIdQuery, Response<UserRolFullDto>>
    {
        private readonly IRepositoryCustom<UserRol> _repository;
        private readonly IMapper _mapper;

        public SelectUserRolByIdQueryHandler(IRepositoryCustom<UserRol> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<UserRolFullDto>> IRequestHandler<SelectUserRolByIdQuery, Response<UserRolFullDto>>.Handle(SelectUserRolByIdQuery request, CancellationToken cancellationToken)
        {
            var userRol = await _repository.GetByIdAsync(request.Id);
            if (userRol == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<UserRolFullDto>(userRol);
                return new Response<UserRolFullDto>(dto);

            }
        }
    }
}