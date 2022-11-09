using ApplicationsServices.Filters;
using Ardalis.Specification;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Specifications
{
    internal class PaginatedPetSpecification : Specification<Pet>
    {
        public PaginatedPetSpecification(PetResponseFilter filter)
        {

            Query.Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize);

            if (!String.IsNullOrEmpty(filter.petName))
                Query.Search(x => x.petName, "%" + filter.petName + "%");

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