using System.ComponentModel.Design;
using Veterinary.DomainClass.Entity;

namespace DomainClass.Common
{
    public class BaseEntity
    {
        //[Key]//clave principal
        public long Id { get; set; }
        public long CreateById { get; set; }
        public DateTime? CreateDate { get; set; }//el signo de interrogación es nulo
        public long LastModifiedById { get; set; }//quien lo modificó
        public DateTime? LastModifiedDate { get; set; }
        public bool IsDeleted { get; set; }

        //public virtual User CreateBy { get; set; }
        //public virtual User LastModifiedBy { get; set; }
    }
}
