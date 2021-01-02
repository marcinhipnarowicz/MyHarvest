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
        public IActionResult Add([FromBody] List<PointOnTheMapVm> pointOnTheMapList, string token)//frombody - to oznacza, ze
        {
            if (pointOnTheMapList.Count == 0)
            {
                return Ok(ResponseManager.GenerateResponse("Błąd: Brak punktów", (int)MessageType.Error, null));
            }
            else
            {
                var idPointsList = _service.AddPointOnTheMap(pointOnTheMapList);

                for (int i = 0; i < pointOnTheMapList.Count; i++)
                {
                    pointOnTheMapList[i].IdPointOnTheMap = idPointsList[i];
                }

                return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, pointOnTheMapList));
            }
        }
    }
}