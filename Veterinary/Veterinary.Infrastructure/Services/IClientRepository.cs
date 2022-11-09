using Veterinary.Core.DTOs;

namespace Veterinary.Infrastructure.Services
{
    public interface IClientRepository: IGenericRepository<ClientFullDto> //Le paso a la clase generica la entidad que va a usar.
    {
        //Cuando se cree un objeto en base a IClientRepository heredará esta propiedad de cliente y todo lo demás de repositorio genérico.
        //Aquí van unicamente los elementos de clientes, que no son iguales para el resto de entidades
        public Task<ClientFullDto> GetById(int id);
        //public Task<ClientFullDto> GetByName(int id);
    }
}