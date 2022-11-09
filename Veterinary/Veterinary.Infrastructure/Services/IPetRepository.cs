using Veterinary.Core.DTOs;

namespace Veterinary.Infrastructure.Services
{
    public interface IPetRepository : IGenericRepository<PetFullDto>
    {
        public Task<PetFullDto> GetById(int id);

    }
}
