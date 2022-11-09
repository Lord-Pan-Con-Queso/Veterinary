using Veterinary.DomainClass.Entity;

namespace Veterinary.Core.DTOs
{
    public class ClientFullDto
    {
        public long Id { get; set; }
        public string? clientName { get; set; }
        public string? clientSurname { get; set; }
        public string? clientAdress { get; set; }
        public string? clientPhoneNum { get; set; }
        public string? clientIdn { get; set; }
        public string? clientEmail { get; set; }
        public bool IsDeleted { get; set; }
    }
}
