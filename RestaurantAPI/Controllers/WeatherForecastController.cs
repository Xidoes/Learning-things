using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get([FromQuery] int count, [FromQuery] int max, [FromQuery] int min)
        {
            var result = _service.Get();
            return result;
        }*/
        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Generate([FromQuery] int count, [FromBody] TemperatureRequest request)
        {
            if (count < 0 || request.max < request.min)
            {
                return BadRequest($"Error");
            }
            var result = _service.Get(count, request.min, request.max);
            return Ok(result);
        }
        /*
        [HttpGet("currentDay2/{max}")]        // 2nd way to create additional get
        //[Route("currentDay")]             //Ability to create additional get, to run this use: https://localhost:5001/weatherforecast/currentday
        public IEnumerable<WeatherForecast> Get2([FromQuery]int take, [FromRoute]int max)
        {
            var result = _service.Get();
            return result;
        }
        [HttpPost]
        
        /*public string Hello([FromBody] string name)    //Post Test
        {
            return $"Hello {name}";
        }*/
        /*
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return $"Hello {name}!"; //1st method
            //return StatusCode(401, $"Hello {name}"); //2nd method
            return NotFound($"Hello {name}");   //3rd method
        }
        */
    }
}
