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
            string codigoErro;

            switch (ex)
            {
                case AppNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    mensagem = ex.Message;
                    codigoErro = "NOT_FOUND";
                    break;

                case AppValidationException:
                case System.ComponentModel.DataAnnotations.ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    mensagem = ex.Message;
                    codigoErro = "VALIDATION_ERROR";
                    break;

                case AppDomainException:
                    statusCode = HttpStatusCode.BadRequest;
                    mensagem = ex.Message;
                    codigoErro = "DOMAIN_ERROR";
                    break;

                //default:
                    //statusCode = HttpStatusCode.InternalServerError;
                    //mensagem = ex.ToString();
                    //mensagem = $"{ex.GetType().Name}: {ex.Message}";
                    //break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    mensagem = "Eita! Nossos robôs se atrapalharam um pouco aqui dentro. Já estamos resolvendo, tente novamente em instantes.";
                    codigoErro = "INTERNAL_ERROR";
                    Console.WriteLine(ex);
                    break;
            }

            var resposta = new
            {
                erro = new
                {
                    codigo = codigoErro,
                    mensagem = mensagem
                }                    
            };

            var json = JsonSerializer.Serialize(resposta);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(json);
        }
    }
}