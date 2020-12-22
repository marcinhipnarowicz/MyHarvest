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
    [TokenAuthoriseAttribute]
    public class StatusOfTaskController : ControllerBase
    {
        private IStatusOfTaskService _service;

        public StatusOfTaskController(IStatusOfTaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetStatusOfTask")]
        public IActionResult Get(string token)
        {
            var statusOfTaskDb = _service.GetAllStatusOfTask();
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, statusOfTaskDb));
        }
    }
}