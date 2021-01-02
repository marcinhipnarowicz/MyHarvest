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
    public class WaypointController : ControllerBase
    {
        private IWaypointService _service;

        public WaypointController(IWaypointService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddWaypoint")]
        public IActionResult Add(List<WaypointVm> waypointList, string token)
        {
            if (waypointList == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Brak punktów", (int)MessageType.Error, null));
            }
            else
            {
                _service.AddWaypoint(waypointList);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
            }
        }

        [HttpGet]
        [Route("GetWaypoints")]
        public IActionResult GetWaypointList(int idUserInformation, string token)
        {
            var waypointListDb = _service.GetWaypointList(idUserInformation);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, waypointListDb));
        }
    }
}