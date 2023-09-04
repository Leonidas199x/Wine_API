using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Text;
using WineAPI.Models;
using Microsoft.Extensions.Options;
using System.Linq;

namespace WineAPI
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IOptions<DebugSettings> _settings;

        public ErrorLoggingMiddleware(RequestDelegate next, ILoggerFactory logger, IOptions<DebugSettings> settings)
        {
            _next = next;
            _logger = logger.CreateLogger(nameof(ErrorLoggingMiddleware));
            _settings = settings;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (_settings.Value.Debug)
                {
                    var info = BuildInfo(context);
                    _logger.LogInformation(info);
                }

                await _next(context);
            }
            catch (Exception e)
            {
                var error = new StringBuilder("An error occured, please review the folling message and stack trace:");
                error.AppendLine($"Message: {e.Message}");
                error.AppendLine($"Stack trace: {e.StackTrace}");

                _logger.LogError($"Error occured: {error}");
            }
        }

        public string BuildInfo(HttpContext context) 
        {
            var info = new StringBuilder($"Endpoint: {context.Request.Path}");
            info.AppendLine($"QueryString: {context.Request.QueryString}");
            info.AppendLine($"Body: {context.Request.BodyReader}");

            return info.ToString();
        }
    }
}
