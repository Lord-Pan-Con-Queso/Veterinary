using ApplicationsServices.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ApplicationsServices
{
    public static class ServiceExtensions
    {
        //Para no tener que ir al program para hacer inyección de dependencias linea por línea. Para eso la hago acá y en el program llamo a este para que llame a todos estos.
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //Inyeccion de dependencia:
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
