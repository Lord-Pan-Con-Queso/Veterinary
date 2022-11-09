using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IUserRolServices
    {
        public Task<int> Insert(UserRol userRol);
    }
}
