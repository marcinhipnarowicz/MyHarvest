using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;
using MyHarvestApi.Repository;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private ApplicationDbContext _db;

        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepo) //ApplicationDbContext dbContext,
        {
            // _db = dbContext;
            _userRepository = userRepo;//= new UserRepository(_db);
        }

        ////[Authorize]
        //[HttpPost]
        //[Route("Register")]
        //public async Task<ActionResult<User>> Add(User user)
        //{
        //    //_db.Users.Add(user);

        //    //await _db.SaveChangesAsync();

        //    return Ok();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            var usersDb = _userRepository.GetUsers();
            return Ok(usersDb); //sam konwertuje na jsona. Ok oznacza status 200
        }
    }
}