using Microsoft.EntityFrameworkCore;
using Veterinary.Core.Entities;

namespace Veterinary.Infrastructure.Data
{
    public class VeterinaryContex : DbContext
    {
        public VeterinaryContex(DbContextOptions<VeterinaryContex> options) : base(options)
        {

        }
        //Representar los modelos en la base de datos:
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Specialty> Specialties => Set<Specialty>();
        public DbSet<Pet> Pets => Set<Pet>();
        public DbSet<Procedure> Procedures => Set<Procedure>();
        public DbSet<UserRol> UserRoles => Set<UserRol>();
        public DbSet<PetType> PetTypes => Set<PetType>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Vet> Vets => Set<Vet>();
        public DbSet<Visit> Visits => Set<Visit>();
        public DbSet<VisitDetail> VisitsDetails => Set<VisitDetail>();

        //Para crear base de datos a travez de los modelos:
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
