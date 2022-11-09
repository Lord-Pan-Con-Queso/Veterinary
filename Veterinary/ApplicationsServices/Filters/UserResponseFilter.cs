using ApplicationsServices.Wrappers;

namespace ApplicationsServices.Filters
{
    public class UserResponseFilter : ParameterResponse
    {
        public string? name { get; set; }
        public string? userSurname { get; set; }
    }
}

