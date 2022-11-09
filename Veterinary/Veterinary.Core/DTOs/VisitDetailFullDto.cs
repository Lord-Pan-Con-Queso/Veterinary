namespace Veterinary.Core.DTOs
{
    public class VisitDetailFullDto
    {
        public int detailId { get; set; }
        public int visitId { get; set; }
        public int procedureId { get; set; }
        public string? price { get; set; }
        //Audit Data.
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
