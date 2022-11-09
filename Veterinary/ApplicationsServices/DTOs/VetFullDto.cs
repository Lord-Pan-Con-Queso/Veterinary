namespace Veterinary.Core.DTOs
{
    public class VetFullDto
    {
        public long Id { get; set; }
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
        public string? verAdress { get; set; }
        public string? verPhoneNum { get; set; }
        public string? vetIdn { get; set; }
        public long specialtyId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
