namespace ecommerce.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _expectedHeaderValue;

        public CustomHeaderMiddleware(RequestDelegate next, string expectedHeaderValue)
        {
            _next = next;
            _expectedHeaderValue = expectedHeaderValue;
        }

        public async Task Invoke(HttpContext context)
        {
            var customHeaderValue = context.Request.Headers["X-Custom-Header"];

            Console.WriteLine($"Received Custom Header Value: {customHeaderValue}, Expected: {_expectedHeaderValue}");

            if (string.IsNullOrEmpty(customHeaderValue) || customHeaderValue != _expectedHeaderValue)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid or missing custom header");
                return;
            }

            await _next(context);
        }
    }

    public static class CustomHeaderMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder, string expectedHeaderValue)
        {
            return builder.UseMiddleware<CustomHeaderMiddleware>(expectedHeaderValue);
        }
    }
}
