using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using MyHarvestApi.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api
{
    public class TokenAuthoriseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;

            if (descriptor != null)
            {
                var parameters = descriptor.MethodInfo.GetParameters();
            }

            base.OnActionExecuting(context);

            var token = context.ModelState.FirstOrDefault(ms => ms.Key == "token");

            if (token.Key == null)
            {
                context.Result = new OkObjectResult(ResponseManager.GenerateResponse("Błąd: \n" + "Błąd autoryzacji - błędny token", (int)MessageType.Error, null));
                return;
            }

            var result = TokenManager.ValidateToken(token.Value.AttemptedValue.Replace("\"", ""));

            if (result == null)
                context.Result = new OkObjectResult(ResponseManager.GenerateResponse("Błąd: \n" + "Błąd autoryzacji - błędny token", (int)MessageType.Error, null));
        }
    }
}