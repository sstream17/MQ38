using System;
using Microsoft.AspNetCore.Mvc;
using MQ38.Manager;

namespace MQ38.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController(IEventManager eventManager)
        {
            EventManager = eventManager;
        }

        private IEventManager EventManager { get; }

        [HttpGet]
        public IActionResult Get(DateTime? startDate, DateTime? endDate)
        {
            var events = EventManager.GetEventDatas(startDate, endDate);

            return Ok(events);
        }
    }
}
