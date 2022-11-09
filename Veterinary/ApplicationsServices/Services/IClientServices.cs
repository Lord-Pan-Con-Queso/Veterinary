using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Services
{
    public interface IClientServices
    {
        //Inserta un cliente en la base de datos.
        public Task<int> Insert(Client client);

    }
}
