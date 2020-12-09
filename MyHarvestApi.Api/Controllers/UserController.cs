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
using MyHarvestApi.Service;
using MyHarvestApi.Service.ViewModel;

namespace MyHarvestApi.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private ApplicationDbContext _db;

        private IUserRepository _userRepository;
        private IUserService _userService;

        public UserController(IUserRepository userRepo, IUserService userService) //ApplicationDbContext dbContext,
        {
            // _db = dbContext;
            _userRepository = userRepo;//= new UserRepository(_db);
            _userService = userService;
        }

        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody] User userParam)
        //{
        //    var user = _userService.Authenticate(userParam.Email, userParam.Password);

        //    if (user == null)
        //        return BadRequest(new { message = "Email lub hasło są niepoprawne" });

        //    return Ok(user);
        //}

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                UserVm user = _userService.GetByEmail(loginVm.Email);
                if (user != null)
                {
                    if (user.Password == loginVm.Password)
                    {
                        return Ok();
                    }
                }
            }

            return BadRequest(new { message = "Email lub hasło są niepoprawne" });
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
        [Route("Get")]
        public IActionResult Get()
        {
            var usersDb = _userRepository.GetUsers();
            return Ok(usersDb); //sam konwertuje na jsona. Ok oznacza status 200
        }
    }
}