using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Entity.Context;
using MyHarvestApi.Entity.Model;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _db;

        public UserController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        //[Authorize]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Users>> Add(Users user)
        {
            //_db.Users.Add(user);

            //await _db.SaveChangesAsync();

            return Ok();
        }

        //[HttpGet]
        //[Route("Register")]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "elo", "ku" };
        //}
    }
}