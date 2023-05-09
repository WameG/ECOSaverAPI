using ECOSaver.Models;
using ECOSaver.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECOSaver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private WeatherRepository _weatherRepository;
        public WeatherController(WeatherRepository weatherRepository)
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

            if (result.Count < 1)
            {
                return NoContent();
            }
            return Ok(result);
        }

        // GET api/<WeatherController>/5
       
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
                return Created($"api/weather/{createdWeather.Id}", createdWeather);
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

        // PUT api/<WeatherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<WeatherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
