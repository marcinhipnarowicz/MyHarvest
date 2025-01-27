﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        private IUserService _userService;

        public int FromQuery { get; private set; }

        public UserController(IUserService userService)
        {
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
            using (SHA256 sha256Hash = SHA256.Create())
            {
                if (ModelState.IsValid)
                {
                    UserVm user = _userService.GetByEmail(login.Email);
                    if (user != null)
                    {
                        var hashPassord = _userService.GetHash(sha256Hash, login.Password);

                        if (user.Password == hashPassord)
                        {
                            //user.Password = login.Password;
                            var token = _userService.Authenticate(user.Email);
                            LoginVm loginVm = LoginMapper.Map(user, token);
                            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, loginVm));
                        }
                    }
                }

                //return BadRequest(new { message = "Email lub hasło są niepoprawne" });
                return Ok(ResponseManager.GenerateResponse("Błąd: Email lub hasło są niepoprawne", (int)MessageType.Error, null));
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserVm user)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                if (user != null)
                {
                    if (_userService.IfExistsUser(user.Email))
                    {
                        //return BadRequest(new { message = "Użytkownik o podanym emailu już istnieje" });
                        return Ok(ResponseManager.GenerateResponse("Błąd: Użytkownik o podanym emailu już istnieje", (int)MessageType.Error, null));
                    }
                    else
                    {
                        if (user.IdAccountType == 1)
                        {
                            user.BossKey = _userService.GetBossKey();
                        }

                        if (user.IdAccountType == 2)
                        {
                            if (_userService.GetIdBoss(user.BossKey) == 0)
                            {
                                //return BadRequest(new { message = "Nie istnieje szef o podanym kodzie" });
                                return Ok(ResponseManager.GenerateResponse("Błąd: Nie istnieje szef o podanym kodzie", (int)MessageType.Error, null));
                            }
                            else
                            {
                                user.IdBoss = _userService.GetIdBoss(user.BossKey);
                                user.BossKey = null;
                            }
                        }

                        var hash = _userService.GetHash(sha256Hash, user.Password);
                        user.Password = hash;

                        var idUser = _userService.AddUser(user);
                        user.Id = idUser;
                        //var token = _userService.Authenticate(user.Email);
                        RegisterVm registerVm = RegisterMapper.MapToVm(user);

                        return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, registerVm));
                    }
                }
                //return BadRequest(new { message = "Podany użytkownik jest pusty" });
                return Ok(ResponseManager.GenerateResponse("Błąd: Podany użytkownik jest pusty", (int)MessageType.Error, null));
            }
        }

        [HttpGet]
        [Route("GetUser")]
        [TokenAuthoriseAttribute]
        public IActionResult GetUser(string email, string token)
        {
            var usersDb = _userService.GetByEmail(email);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, usersDb));

            //return Ok(usersDb); //sam konwertuje na jsona. Ok oznacza status 200
        }

        [HttpGet]
        [Route("GetForBoss")]//user/getForBoss?idboss=54
        [TokenAuthoriseAttribute]
        public IActionResult GetUserFromBossList([FromQuery] int idBoss, string token)
        {
            try
            {
                var usersVm = _userService.GetEmployeeForBoss(idBoss);

                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, usersVm));
            }
            catch (Exception ex)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: \n" + ex.Message, (int)MessageType.Error, null));
            }
        }

        [HttpGet]
        [Route("GetBossForUser")]//user/getBossForUser?iduser=54
        [TokenAuthoriseAttribute]
        public IActionResult GetBossForUser([FromQuery] int idUser, string token)
        {
            try
            {
                var usersVm = _userService.GetBossFromUser(idUser);

                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, usersVm));
            }
            catch (Exception ex)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: \n" + ex.Message, (int)MessageType.Error, null));
            }
        }

        [HttpPost]
        [Route("RemoveBossOfEmployee")]
        [TokenAuthoriseAttribute]
        public IActionResult RemoveBossOfEmployee([FromQuery] int id, string token)
        {
            _userService.RemoveBossOfEmployee(id);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
        }

        [HttpPost]
        [Route("AddNewBossForEmployee")]
        [TokenAuthoriseAttribute]
        public IActionResult AddNewBossForEmployee(UserVm user, int id, string token)
        {
            if (user == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: podane zadanie jest puste", (int)MessageType.Error, null));
            }
            else
            {
                _userService.AddNewBossForEmployee(user, id);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
            }
        }
    }
}