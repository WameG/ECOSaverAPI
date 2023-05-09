using ECOSaver.Models;

namespace ECOSaver.Repositories
{
    public class WeatherRepository
    {
        private List<Weather> _weathers;

        public WeatherRepository()
        {
            _weathers = new List<Weather>();
        }

        public List<Weather> GetAll()
        {
            return new List<Weather>(_weathers);
        }

        public Weather Add(Weather newWeather) {
            newWeather.Validate();
            _weathers.Add(newWeather);
            return newWeather;
        }
    }
}
