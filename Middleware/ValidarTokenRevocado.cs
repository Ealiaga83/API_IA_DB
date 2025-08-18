using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

using API_IA_DB.Servicios;

namespace API_IA_DB.Middleware
{
    public class ValidarTokenRevocado
    {
        private readonly RequestDelegate next;

        public ValidarTokenRevocado(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, TokenRevocadoService revocadoService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            if (!string.IsNullOrEmpty(token) && revocadoService.EstaRevocado(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Token revocado");
                return;
            }

            await next(context);
        }
    }
}
