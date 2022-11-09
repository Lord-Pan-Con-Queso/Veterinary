namespace Veterinary.Core.DTOs
{
    public class UserFullDto
    {
        public int userId { get; set; }
        public string? userName { get; set; }
        public string? userSurname { get; set; }
        public string? userPhoneNum { get; set; }
        public string? userAdress { get; set; }
        public int rolId { get; set; }
        public string? email { get; set; }

        //Audit Data
        public DateTime dateUpload { get; set; }
        public DateTime dateUpdate { get; set; }
        public int user { get; set; }
    }
}
