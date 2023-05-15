using ECOSaver.Contexts;
using ECOSaver.Models;

namespace ECOSaver.Repositories
{
    public class WeatherRepositoryDB : IWeatherRepository
    {

        //private int _nextId;
        private WeatherContext _weatherContext;
        public WeatherRepositoryDB(WeatherContext weatherContext)
        {
            //_nextId = 1;
            _weatherContext = weatherContext;
        }

        public List<Weather> GetAll()
        {
            return _weatherContext.weathers.ToList();
        }

        public Weather Add(Weather newWeather)
        {
            newWeather.Id = null;
            newWeather.Date = DateTime.Now;
            _weatherContext.weathers.Add(newWeather);
            _weatherContext.SaveChanges();
            return newWeather;
        }
    }
}
