using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Vet : BaseEntity
    {
        public string? vetName { get; set; }
        public string? vetSurname { get; set; }
        public string? verAdress { get; set; }
        public string? verPhoneNum { get; set; }
        public string? vetIdn { get; set; }
        public long specialtyId { get; set; }
    }
}
