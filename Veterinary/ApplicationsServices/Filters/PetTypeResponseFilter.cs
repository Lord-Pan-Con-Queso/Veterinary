using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters
{
    public class PetTypeResponseFilter : ParameterResponse
    {
        public string? type { get; set; }
    }
}