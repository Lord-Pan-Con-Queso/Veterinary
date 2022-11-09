using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters
{
    public class PetResponseFilter : ParameterResponse
    {
        public string? petName { get; set; }
    }
}

