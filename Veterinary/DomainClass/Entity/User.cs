using DomainClass.Common;

namespace Veterinary.DomainClass.Entity
{
    public class User : BaseEntity
    {
        private string _password;
        public string name { get; set; }
        public string userSurname { get; set; }
        public string userName { get; set; }
        public string password { get { return _password; } set { _password = value.Encriptar(); } }
        public string email { get; set; }
        public string? userPhoneNum { get; set; }
        public long userRol { get; set; }


    }
}
