namespace Veterinary.Core.DTOs
{
    public class VisitDetailFullDto
    {
        public long Id { get; set; }
        public long visitId { get; set; }
        public long procedureId { get; set; }
        public string? price { get; set; }
        public bool IsDeleted { get; set; }
    }
}
