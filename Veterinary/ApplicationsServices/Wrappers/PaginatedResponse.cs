using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Wrappers
{
    public class PaginatedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool IsDeleted { get; set; }

        public PaginatedResponse(T data, int pageNumber, int pageSize, bool isDeleted)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Successful = true;
            Errors = null;
            IsDeleted = IsDeleted;
        }
    }
}
