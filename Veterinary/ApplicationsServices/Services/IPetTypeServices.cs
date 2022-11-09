using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IPetTypeServices
    {
        public Task<int> Insert(PetType petType);
    }
}
