using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Service;
using MyHarvestApi.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private IAccountTypeService _service;

        public AccountTypeController(IAccountTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAccountType")]
        public IActionResult Get()
        {
            var accountTypesDb = _service.GetAllAccountType();
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, accountTypesDb));
        }
    }
}