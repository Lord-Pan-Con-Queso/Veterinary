namespace Veterinary.Core.DTOs
{
    public class VisitFullDto
    {
        public int visitId { get; set; }
        public int petId { get; set; }
        public int vetId { get; set; }
        public DateTime visitDate { get; set; }
        //Audit Data.
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
