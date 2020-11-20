using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Repository;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepo)
        {
            _taskRepository = taskRepo;
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

        //[HttpPost]
        //public Task<IActionResult> Add(Task task)
        //{
        //    _taskRepository.Add(task);

        //    return Ok();
        //}

        //PUT api/task/1
        [HttpPut]
        public async Task<ActionResult<Task>> Edit(int id, Task task)
        {
            if (id != task.IdTask)
            {
                return BadRequest();
            }

            try
            {
                _taskRepository.EditTask(id, task);
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