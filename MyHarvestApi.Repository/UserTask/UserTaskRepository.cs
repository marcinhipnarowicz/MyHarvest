﻿using MyHarvestApi.Entity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private ApplicationDbContext _db;

        public UserTaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }
    }
}