using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = MyHarvestApi.Entity.Model.Task;

namespace MyHarvestApi.Repository
{
    public interface ITaskRepository
    {
        List<Task> GetTasks();

        Task GetOneTask(int id);

        void Add(Task task);

        void EditTask(int id, Task task);

        bool IfTaskExist(int id);
    }
}