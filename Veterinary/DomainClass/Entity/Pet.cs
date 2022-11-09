using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Pet : BaseEntity
    {
        public string? petName { get; set; }
        public long clientId { get; set; }
        public long petTypeId { get; set; }

        public virtual PetType? petType { get; set; }
        public virtual Client? client { get; set; }   
    }
}
