using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class VisitDetail : BaseEntity
    {
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }
    }
}
