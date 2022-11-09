namespace Veterinary.Core.DTOs
{
    public class UserFullDto
    {
        public long Id { get; set; }
        public string? userName { get; set; }
        public string? userSurname { get; set; }
        public string? userPhoneNum { get; set; }
        public string? userAdress { get; set; }
        public string? password { get; set; }
        public string? email { get; set; }
        public bool IsDeleted { get; set; }

    }
}
