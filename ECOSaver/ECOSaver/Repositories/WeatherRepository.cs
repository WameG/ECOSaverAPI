using ECOSaver.Models;
using System.Runtime.InteropServices;

namespace ECOSaver.Repositories
{
    public class WeatherRepository
    {
        private int _nextId;
        private List<Weather> _weathers;

        public WeatherRepository()
        {
            _nextId = 1;
            _weathers = new List<Weather>();
        }

        public List<Weather> GetAll()
        {
            return new List<Weather>(_weathers);
        }

        public Weather Add(Weather newWeather) {
            newWeather.Validate();
            newWeather.Id = _nextId++;
            _weathers.Add(newWeather);
            return newWeather;
        }
    }
}
