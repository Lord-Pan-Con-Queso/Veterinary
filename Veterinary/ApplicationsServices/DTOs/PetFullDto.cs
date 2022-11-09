using Veterinary.DomainClass.Entity;

namespace Veterinary.Core.DTOs
{
    public class PetFullDto
    {
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long petTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual PetType? petType { get; set; }
        public virtual Client? client { get; set; }

    }
}
