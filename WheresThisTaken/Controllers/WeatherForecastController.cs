using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheresThisTaken.Models;
using WheresThisTaken.Services;

namespace WheresThisTaken.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // private readonly LocationService _locationService;
        private readonly PlaceService _placeService;
        public WeatherForecastController(PlaceService placeService)
        {
            _placeService = placeService;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ILogger<WeatherForecastController> _logger;

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            String locs = await _placeService.GetCandidatesAsync("Alta","NO");
            return Content("dd" + locs);
        }
    }
}
