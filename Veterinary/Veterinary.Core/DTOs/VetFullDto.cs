namespace Veterinary.Core.DTOs
{
    public class VetFullDto
    {
        public int vetId { get; set; }
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
        public string? verAdress { get; set; }
        public string? verPhoneNum { get; set; }
        public string? vetIdn { get; set; }
        public int specialtyId { get; set; }
        //Audit Data.
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
