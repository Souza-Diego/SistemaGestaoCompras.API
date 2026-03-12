using System.Net;
using System.Text.Json;
using SistemaGestaoCompras.Domain.Exceptions;

namespace SistemaGestaoCompras.API.Middlewares
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
            catch (Exception ex)
            {
                await TratarExcecaoAsync(context, ex);
            }
        }

        private static Task TratarExcecaoAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode;
            string mensagem;

            switch (ex)
            {
                case NotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    mensagem = ex.Message;
                    break;

                case ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    mensagem = ex.Message;
                    break;

                case DomainException:
                    statusCode = HttpStatusCode.BadRequest;
                    mensagem = ex.Message;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    mensagem = "Erro interno do servidor";
                    break;
            }

            var resposta = new
            {
                erro = mensagem
            };

            var json = JsonSerializer.Serialize(resposta);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(json);
        }
    }
}