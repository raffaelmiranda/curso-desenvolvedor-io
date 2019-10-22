using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspNetCoreIdentity2.Extensions
{
    public class AuditFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public AuditFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context){ }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var message = $"{context.HttpContext.User.Identity.Name} acessou {UriHelper.GetDisplayUrl(context.HttpContext.Request)}";

                _logger.LogInformation(message);
            }
        }
    }
}
