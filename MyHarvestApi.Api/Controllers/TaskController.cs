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
        private ITaskRepository _taskRepository;//wyrzucić
        private ITaskService _taskService;

        public TaskController(ITaskRepository taskRepo, ITaskService taskService)
        {
            _taskRepository = taskRepo;
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasksDb = _taskRepository.GetTasks();
            return Ok(tasksDb);
        }

        // GET api/task/1
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var singleTask = _taskRepository.GetOneTask(id);
            return Ok(singleTask);
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
                _taskService.AddTask(task);
                task.IdTask = _taskService.GetMaxId();
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, task));
            }
        }

        //RemoveTask

        [HttpPost]
        [Route("RemoveTask")]
        [TokenAuthoriseAttribute]
        public IActionResult RemoveTask([FromQuery] int id, string token)
        {
            _taskService.RemoveTask(id);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
        }

        //PUT api/task/1
        [HttpPut("{id}")]
        public ActionResult<Task> Edit(int id, Task task)
        {
            if (id != task.IdTask)
            {
                return BadRequest();
            }
            _taskRepository.EditTask(id, task);

            try
            {
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_taskRepository.IfTaskExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }
    }
}