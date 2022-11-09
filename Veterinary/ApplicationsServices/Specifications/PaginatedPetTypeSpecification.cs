using ApplicationsServices.Filters;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications
{
    internal class PaginatedPetTypeSpecification : Specification<PetType>
    {
        public PaginatedPetTypeSpecification(PetTypeResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.type))
                Query.Search(x => x.type, "%" + filter.type + "%");

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
