using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Wrappers
{
    public class ParameterResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsDeleted { get; set; }
        public ParameterResponse()
        {
            PageNumber = 1;
            PageSize = 15;
        }
        public ParameterResponse(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 15 ? 15 : pageSize;
        }


    }
}
