namespace Veterinary.Infrastructure.Services
{
    public interface IGenericRepository<T>
    {
        //T hace referencia a que va a recibir o guardar un tipo genérico.
        public Task<IEnumerable<T>> GetAll();
        public Task Insert (T entity);
        public Task Update (T entity);
        public Task Delete (int Id);
          
    }
}
