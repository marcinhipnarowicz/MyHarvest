﻿using Microsoft.AspNetCore.Mvc;
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
        private IPlotService _service;

        public PlotController(IPlotService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddPlot(PlotVm plot)
        {
            _service.AddPlot(plot);
            return Ok(ResponseManager.GenerateResponse(null, (int)MessageType.Ok, plot));
        }
    }
}