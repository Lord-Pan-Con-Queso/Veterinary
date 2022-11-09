using Veterinary.Core.DTOs;

namespace Veterinary.Infrastructure.Services
{
    public interface IPetTypeRepository:IGenericRepository<PetTypeFullDto>
    {
        public Task<PetTypeFullDto> GetById(int id);
    }
}
