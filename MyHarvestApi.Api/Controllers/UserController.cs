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
using MyHarvestApi.Service.Enum;
using MyHarvestApi.Service.ViewModel;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IUserService _userService;

        public UserController(IUserRepository userRepo, IUserService userService)
        {
            _userRepository = userRepo;
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] User userParam)
        {
            var user = _userService.Authenticate(userParam.Email);

            if (user == null)
                return BadRequest(new { message = "Email lub hasło są niepoprawne" });

            return Ok(user);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginVm login)
        {
            if (ModelState.IsValid)
            {
                UserVm user = _userService.GetByEmail(login.Email);
                if (user != null)
                {
                    if (user.Password == login.Password)
                    {
                        var token = _userService.Authenticate(user.Email);
                        LoginVm loginVm = LoginMapper.Map(user, token);
                        return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, loginVm));
                    }
                }
            }

            return BadRequest(new { message = "Email lub hasło są niepoprawne" });
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserVm user)
        {
            if (user != null)
            {
                if (_userService.IfExists(user.Email))
                {
                    return BadRequest(new { message = "Użytkownik o podanym emailu już istnieje" });
                }
                else
                {
                    _userService.AddUser(user);
                    return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, user));
                }
            }
            return BadRequest(new { message = "Podany użytkownik jest pusty" });
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var usersDb = _userRepository.GetUsers();
            return Ok(usersDb); //sam konwertuje na jsona. Ok oznacza status 200
        }
    }
}