using ApplicationsServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repository;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //MigrationAssembly: configura el ensamblado donde se mantienen las migraciones para este contexto.
            //El operador typeof obtiene la instancia Syste.Type para un tipo.
            //Ej: int edad;
            //    Console.WriteLine((typeof(edad)));
            //La salida por pantalla sera: System.Int32.
            //Assembly: obtiene la propiedad Assembly en la que está declarado el tipo.
            //FullName: obtiene el nombre para mostrar el ensamblado.
            services.AddDbContext<VeterinaryAppContext>(options => options.UseSqlServer(configuration.GetConnectionString
                ("MsSqlServer"), c => c.MigrationsAssembly(typeof(VeterinaryAppContext).Assembly.FullName)));

            #region Repositories
            services.AddTransient(typeof(IRepositoryCustom<>), typeof(RepositoryCustom<>));
            #endregion
        }
    }
}
