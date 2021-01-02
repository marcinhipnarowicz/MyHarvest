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
    public class PointOnTheMapController : ControllerBase
    {
        private IPointOnTheMapService _service;

        public PointOnTheMapController(IPointOnTheMapService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("AddPointOnTheMap")]
        public IActionResult Add(List<PointOnTheMapVm> pointOnTheMapList, string token)
        {
            if (pointOnTheMapList == null)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Brak punktów", (int)MessageType.Error, null));
            }
            else
            {
                _service.AddPointOnTheMap(pointOnTheMapList);
                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, null));
            }
        }
    }
}