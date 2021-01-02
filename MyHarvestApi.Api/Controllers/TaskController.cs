using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Repository;
using MyHarvestApi.Service;
using MyHarvestApi.Service.Enum;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        [Route("AddTask")]
        [TokenAuthoriseAttribute]
        public IActionResult Add(TaskVm task, string token)
        {
            if (task == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: podane zadanie jest puste", (int)MessageType.Error, null));
            }
            else
            {
                var idTask = _taskService.AddTask(task);
                task.IdTask = idTask;
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, task));
            }
        }

        [HttpPost]
        [Route("RemoveTask")]
        [TokenAuthoriseAttribute]
        public IActionResult RemoveTask([FromQuery] int id, string token)
        {
            _taskService.RemoveTask(id);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
        }

        [HttpPost]
        [Route("EditTask")]
        [TokenAuthoriseAttribute]
        public IActionResult EditTask(TaskVm task, string token)
        {
            if (task == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Informacje dla użytkownika są puste", (int)MessageType.Error, null));
            }
            else
            {
                _taskService.EditTask(task);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null)); ;
            }
        }
    }
}