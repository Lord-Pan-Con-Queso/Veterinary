using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IUserServices
    {
        public Task<int> Insert(User user);

    }
}
