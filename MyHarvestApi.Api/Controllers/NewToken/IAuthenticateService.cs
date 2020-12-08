using MyHarvestApi.Api.Token;
using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Controllers.NewToken
{
    public interface IAuthenticateService
    {
        bool IsAuthenticated(User request, out string token);
    }
}