using Microsoft.AspNetCore.Mvc;
using MyHarvestApi.Service;
using MyHarvestApi.Service.Enum;
using MyHarvestApi.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TokenAuthoriseAttribute]
    public class UserInformationController : ControllerBase
    {
        private IUserInformationService _service;

        public UserInformationController(IUserInformationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddUserInformation")]
        public IActionResult Add(UserInformationVm userInformation, string token)
        {
            if (userInformation == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Informacje dla użytkownika są puste", (int)MessageType.Error, null));
            }
            else
            {
                _service.AddUserInformation(userInformation);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
            }
        }

        [HttpGet]
        [Route("GetInformationAboutTask")]
        public IActionResult Get(int id, string token)
        {
            var userInformationDb = _service.GetAllInformationAboutTaskList(id);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, userInformationDb));
        }
    }
}