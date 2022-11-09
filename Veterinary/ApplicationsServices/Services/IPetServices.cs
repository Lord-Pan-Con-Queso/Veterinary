using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IPetServices
    {
        public Task<int> Insert(Pet pet);

    }
}
