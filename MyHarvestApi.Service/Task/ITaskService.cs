﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Service
{
    public interface ITaskService
    {
        int AddTask(TaskVm taskVm);

        int GetMaxId();

        void RemoveTask(int id);

        void EditTask(TaskVm taskVm);
    }
}