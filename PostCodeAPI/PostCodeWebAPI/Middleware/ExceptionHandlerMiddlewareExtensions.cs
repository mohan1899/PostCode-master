using Microsoft.AspNetCore.Builder;


namespace PostCodeWebAPI.Middleware
{
    /// <summary>
    /// Extension method for custom pipeline
    /// </summary>
    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}