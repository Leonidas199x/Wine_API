using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Text;
using Microsoft.Extensions.Options;

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
                    var info = await BuildInfo(context).ConfigureAwait(false);
                    _logger.LogInformation(info);
                }

                await _next(context);
            }
            catch (Exception e)
            {
                LogError(e);

                context.Response.Redirect("/Error");
            }
        }

        private async Task<string> BuildInfo(HttpContext context) 
        {
            var queryString = context.Request.QueryString.ToString();
            var body = await GetBody(context).ConfigureAwait(false);

            var info = new StringBuilder("Wine API Request.");
            info.AppendLine(Environment.NewLine);
            info.AppendLine($"Endpoint: {context.Request.Path}");

            if (!string.IsNullOrEmpty(queryString) ) 
            {
                info.AppendLine(Environment.NewLine);
                info.AppendLine($"QueryString: {queryString}");
            }

            if (!string.IsNullOrWhiteSpace(body)) 
            {
                info.AppendLine(Environment.NewLine);
                info.AppendLine($"Body: {body}");
            }

            return info.ToString();
        }

        private async Task<string> GetBody(HttpContext context) 
        {
            context.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(context.Request.ContentLength)];
            await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);

            var requestContent = Encoding.UTF8.GetString(buffer);

            //rewinding the stream to 0 so body is available in the request
            context.Request.Body.Position = 0;

            return requestContent;
        }

        private void LogError(Exception e)
        {
            var error = new StringBuilder("An error occured, please review the folling message and stack trace:");
            error.AppendLine($"Message: {e.Message}");
            error.AppendLine($"Stack trace: {e.StackTrace}");

            _logger.LogError($"Error occured: {error}");
        }
    }
}
