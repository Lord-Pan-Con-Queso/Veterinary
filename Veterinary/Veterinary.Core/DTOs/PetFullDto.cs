namespace Veterinary.Core.DTOs
{
    public class PetFullDto
    {
        public int petId { get; set; }
        public string? petName { get; set; }
        public int clientId { get; set; }
        public int typeId { get; set; }
        //Datos de auditoría.
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
