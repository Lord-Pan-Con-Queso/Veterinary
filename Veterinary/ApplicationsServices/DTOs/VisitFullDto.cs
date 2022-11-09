using Veterinary.DomainClass.Entity;

namespace Veterinary.Core.DTOs
{
    public class VisitFullDto
    {
        public long Id { get; set; }
        public long petId { get; set; }
        public long vetId { get; set; }
        public DateTime visitDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
