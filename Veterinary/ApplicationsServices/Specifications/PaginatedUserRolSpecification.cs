using ApplicationsServices.Filters;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications
{
    internal class PaginatedUserRolSpecification : Specification<UserRol>
    {
        public PaginatedUserRolSpecification(UserRolResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.rol))
                Query.Search(x => x.rol, "%" + filter.rol + "%");

            if (filter.IsDeleted == true)
            {
                Query.Where(x => x.IsDeleted == true);
            }
            else
            {
                Query.Where(x => x.IsDeleted == false);
            }
        }
    }
}