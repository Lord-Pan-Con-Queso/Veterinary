using ApplicationsServices.Filters;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications 
{
    internal class PaginatedUserSpecification : Specification<User>
{
    public PaginatedUserSpecification(UserResponseFilter filter)
    {

        Query.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize);

        if (!String.IsNullOrEmpty(filter.name))
            Query.Search(x => x.name, "%" + filter.name + "%");

        if (!String.IsNullOrEmpty(filter.userSurname))
            Query.Search(x => x.userSurname, "%" + filter.userSurname + "%");

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
