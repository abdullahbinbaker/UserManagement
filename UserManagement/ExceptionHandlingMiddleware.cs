namespace UserManagement.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string localApiKey = "12345";
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (!context.Request.Headers.TryGetValue("ApiKey", out var apiKay))
                {
                    context.Response.StatusCode =
                        StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("ApiKay is missing");
                    return;
                }
                if (apiKay.ToString() != localApiKey)
                {
                    context.Response.StatusCode =
                       StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid ApiKay");
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                context.Response.ContentType = "Text /plain";
                await context.Response.WriteAsync("حدث خطأ في النظام");
            }
        }
    }
}