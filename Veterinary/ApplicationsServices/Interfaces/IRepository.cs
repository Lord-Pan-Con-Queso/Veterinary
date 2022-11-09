using Ardalis.Specification;

namespace ApplicationsServices.Interfaces
{
    public interface IRepositoryCustom<T> : IRepositoryBase<T> where T : class
    {
    }
    public interface IReadRepositoryCustom<T> : IReadRepositoryBase<T> where T : class
    {
    }
}
