﻿using MyHarvestApi.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvestApi.Repository
{
    public interface IUserRepository
    {
        List<User> GetUsers();

        User GetUserByEmail(string email);
    }
}