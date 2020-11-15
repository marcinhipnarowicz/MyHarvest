using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Repository;

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
    }
}