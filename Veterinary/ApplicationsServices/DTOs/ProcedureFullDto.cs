namespace Veterinary.Core.DTOs
{
    public class ProcedureFullDto
    {
        public long Id { get; set; }
        public string? procedure { get; set; }
        public bool IsDeleted { get; set; }

    }
}
