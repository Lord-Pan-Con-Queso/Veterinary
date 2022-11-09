namespace Veterinary.Core.DTOs
{
    public class ProcedureFullDto
    {
        public int procedureId { get; set; }
        public string? procedure { get; set; }

        //Audit Data
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
