namespace Veterinary.Core.DTOs
{
    public class PetTypeFullDto
    {
        public int typeId { get; set; }
        public string? type { get; set; }

        //Audit data
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int usuario { get; set; }
    }
}
