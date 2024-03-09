using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication_AuthenticationService.PLL.Exeptions;

namespace WebApplication_AuthenticationService.PLL.Handlers
{
    public class ExeptionHandler : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string message = "Произошла непредсвиленная ошибка.";

            if (context.Exception is CustomExeption)
            {
                message = context.Exception.Message;
            }

            context.Result = new BadRequestObjectResult(message);
        }
    }
}
