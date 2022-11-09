using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class Visit : BaseEntity
    {
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }

    }
}