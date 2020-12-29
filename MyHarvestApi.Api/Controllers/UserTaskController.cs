using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Service;
using MyHarvestApi.Service.Enum;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenAuthoriseAttribute]
    public class UserTaskController : ControllerBase
    {
        private IUserTaskService _service;

        public UserTaskController(IUserTaskService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddUserTask")]
        public IActionResult Add(UserTaskVm userTask, string token)
        {
            if (userTask == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Informacje dla użytkownika są puste", (int)MessageType.Error, null));
            }
            else
            {
                _service.AddUserTask(userTask);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
            }
        }

        [HttpGet]
        [Route("GetInformationAboutTask")]
        public IActionResult Get(int id, string token)
        {
            var userTaskDb = _service.GetAllInformationAboutTaskList(id);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, userTaskDb));
        }
    }
}