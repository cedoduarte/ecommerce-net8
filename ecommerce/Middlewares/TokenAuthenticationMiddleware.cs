using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ecommerce.Middlewares
{
    public class TokenAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validToken;

        public TokenAuthenticationMiddleware(RequestDelegate next, string validToken)
        {
            _next = next;
            _validToken = validToken;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != _validToken)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid token");
                return;
            }

            await _next(context);
        }
    }

    public static class TokenAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenAuthentication(this IApplicationBuilder builder, string validToken)
        {
            return builder.UseMiddleware<TokenAuthenticationMiddleware>(validToken);
        }
    }
}
