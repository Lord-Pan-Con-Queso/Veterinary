using Veterinary.WebApi.Middleware;

namespace Veterinary.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddlerware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddlerware>();
        }
    }
}