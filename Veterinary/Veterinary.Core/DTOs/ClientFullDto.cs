namespace Veterinary.Core.DTOs
{
    public class ClientFullDto
    {
        public int clientId { get; set; }
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string? clientPhoneNum { get; set; }
        public string? clientIdn { get; set; }

        //Datos de auditoría
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
