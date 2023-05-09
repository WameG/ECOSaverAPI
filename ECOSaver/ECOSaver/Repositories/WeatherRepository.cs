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
            throw new NotImplementedException();
        }

        public Weather Add(Weather newWeather) {
            throw new NotImplementedException();
        }

        public Weather Delete(int id) { 
            throw new NotImplementedException();
        }
    }
}
