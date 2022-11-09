namespace Veterinary.Core.DTOs
{
    public class UserRolFullDto
    {
        public int rolId { get; set; }
        public string? rol { get; set; }

        //Audit Data
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
