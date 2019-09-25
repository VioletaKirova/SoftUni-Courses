namespace Eventures.App.Infrastructure.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using System;

    public class AdminActivityLoggerFilter : IActionFilter
    {
        private readonly ILogger<AdminActivityLoggerFilter> logger;

        public AdminActivityLoggerFilter(ILogger<AdminActivityLoggerFilter> logger)
        {
            this.logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
