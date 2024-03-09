using System.Net;
using WebApplication_AuthenticationService.PLL.Logging;

namespace WebApplication_AuthenticationService.PLL.Middlewares
{
    public class LogMiddleware
    {
        private readonly Logging.ILogger _logger;
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next, Logging.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress;

            if (remoteIpAddress != null)
            {
                string ipAddress = remoteIpAddress.ToString();

                _logger.WriteEvent(ipAddress);
            }
            else
            {
                _logger.WriteEvent("IP Address is not available.");
            }

            await _next(httpContext);
        }
    }
}
