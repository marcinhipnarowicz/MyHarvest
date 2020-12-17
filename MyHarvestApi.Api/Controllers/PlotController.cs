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
    public class PlotController : ControllerBase
    {
        private IPlotService _plotService;

        [HttpPost]
        [Route("Add")]
        public IActionResult AddPlot(PlotVm plot)
        {
            _plotService.AddPlot(plot);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, plot));
        }
    }
}