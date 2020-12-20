using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Service
{
    public class TaskMapper
    {
        public static Task MapFromVm(TaskVm taskVm)
        {
            return new Task
            {
                IdTask = taskVm.IdTask,
                Name = taskVm.Name,
                Description = taskVm.Description,
                IdPlot = taskVm.IdPlot
            };
        }
    }
}