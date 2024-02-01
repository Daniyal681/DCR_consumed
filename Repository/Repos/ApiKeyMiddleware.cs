using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Repos
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyMiddleware : Attribute
    {
        private readonly IConfiguration _config;
        private readonly RequestDelegate _next;
        private const string APIKEY = "XApiKey";

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out
                    var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = _config.GetSection(APIKEY);
            if (!apiKey.Value.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }
            await _next(context);
        }
    }
}
