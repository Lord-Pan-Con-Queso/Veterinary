using Ardalis.Specification;
using Veterinary.DomainClass.Entity;
using ApplicationsServices.Filters;

namespace ApplicationsServices.Specifications
{
    internal class PaginatedClientSpecification : Specification<Client>
    {
        public PaginatedClientSpecification(ClientResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.clientName))
                Query.Search(x => x.clientName, "%" + filter.clientName + "%");

            if (!String.IsNullOrEmpty(filter.clientSurname))
                Query.Search(x => x.clientSurname, "%" + filter.clientSurname + "%");

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
