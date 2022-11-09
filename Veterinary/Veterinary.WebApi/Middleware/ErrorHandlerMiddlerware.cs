using ApplicationsServices.Exceptions;
using ApplicationsServices.Wrappers;
using System.Text.Json;

namespace Veterinary.WebApi.Middleware
{
    public class ErrorHandlerMiddlerware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddlerware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            
            catch (Exception err) //Poner el cursor sobre err si se detiene el programa para ver el mensaje de error.
            {
                var response = context.Response; //Parar aca para ver errores
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Successful = false, Message = err?.Message };
                switch (err)
                {
                    case ApiExceptions e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ValidationExceptions e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
