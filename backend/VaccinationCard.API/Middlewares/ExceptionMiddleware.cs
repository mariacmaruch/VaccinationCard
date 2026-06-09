using FluentValidation;
using System.Text.Json;

namespace VaccinationCard.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    success = false,
                    errors = ex.Errors.Select(x => new
                    {
                        field = x.PropertyName,
                        message = x.ErrorMessage
                    })
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    message = "Erro interno."
                });
            }
        }
    }
}
