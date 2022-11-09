using DomainClass.Common;
using Microsoft.EntityFrameworkCore;
using Veterinary.DomainClass.Entity;

namespace Persistence.Contexts
{
    public class VeterinaryAppContext : DbContext
    {
        public VeterinaryAppContext(DbContextOptions<VeterinaryAppContext> options) : base(options)
        {
            //Configurar QueryTrackingBehavior como NoTracking impide el seguimiento de cambios
            //que se realizan en las entidades del contexto, por tal motivo, si se realizan cambios
            //estos no se veran reflejados en el base de datos.
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Client> Clients { get; set; }
        DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        DbSet<UserRol> UserRols { get; set; }


        //--------------------------------------------------------------------//
        ////Representar los modelos en la base de datos:
        //public DbSet<Client> Clients => Set<Client>();
        //public DbSet<Specialty> Specialties => Set<Specialty>();
        //public DbSet<Pet> Pets => Set<Pet>();
        //public DbSet<Procedure> Procedures => Set<Procedure>();
        //public DbSet<UserRol> UserRoles => Set<UserRol>();
        //public DbSet<PetType> PetTypes => Set<PetType>();
        //public DbSet<User> Users => Set<User>();
        //public DbSet<Vet> Vets => Set<Vet>();
        //public DbSet<Visit> Visits => Set<Visit>();
        //public DbSet<VisitDetail> VisitsDetails => Set<VisitDetail>();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        //entry.Entity.LastModifiedBy = 0;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        //entry.Entity.CreateBy = 0;
                        entry.Entity.CreateDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.IsDeleted = false;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        ////Para crear base de datos a travez de los modelos:
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().ToTable("Clients");
        //    modelBuilder.Entity<Pet>().ToTable("Pets");
        //    modelBuilder.Entity<PetType>().ToTable("PetsType");
        //    modelBuilder.Entity<Procedure>().ToTable("Procedures");
        //    modelBuilder.Entity<Specialty>().ToTable("Specialties");
        //    modelBuilder.Entity<User>().ToTable("Users");
        //    modelBuilder.Entity<UserRol>().ToTable("UserRoles");
        //    modelBuilder.Entity<Vet>().ToTable("Vets");
        //    modelBuilder.Entity<Visit>().ToTable("Visits");
        //    modelBuilder.Entity<VisitDetail>().ToTable("VisitsDetails");
        //}
    }
}

    
