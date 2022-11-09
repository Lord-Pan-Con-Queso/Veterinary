using ApplicationsServices.Interfaces;
using ApplicationsServices.Wrappers;
using AutoMapper;
using MediatR;
using Veterinary.Core.DTOs;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Features.Queries.SelectByQueries
{
    public class SelectUserByIdQuery : IRequest<Response<UserFullDto>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectUserByIdQueryHandler : IRequestHandler<SelectUserByIdQuery, Response<UserFullDto>>
    {
        private readonly IRepositoryCustom<User> _repository;
        private readonly IMapper _mapper;

        public SelectUserByIdQueryHandler(IRepositoryCustom<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<UserFullDto>> IRequestHandler<SelectUserByIdQuery, Response<UserFullDto>>.Handle(SelectUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<UserFullDto>(user);
                return new Response<UserFullDto>(dto);

            }
        }
    }

}
