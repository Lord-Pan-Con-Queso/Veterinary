using ApplicationsServices.Wrappers;
using Veterinary.DomainClass.Entity;

namespace ApplicationsServices.Filters
{
    public class ClientResponseFilter : ParameterResponse
    {
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
    }
}

