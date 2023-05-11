using ECOSaver.Models;
using ECOSaver.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECOSaver.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IWeatherRepository _weatherRepository;
        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        // GET: api/<WeatherController>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpGet]
        public ActionResult<IEnumerable<Weather>> Get()
        {
            List<Weather> result = _weatherRepository.GetAll();

            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // POST api/<WeatherController>
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<Weather> Post([FromBody] Weather newWeather)
        {
            try
            {
                Weather createdWeather = _weatherRepository.Add(newWeather);
                return Created($"api/Weather/{createdWeather.Date}", createdWeather);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
