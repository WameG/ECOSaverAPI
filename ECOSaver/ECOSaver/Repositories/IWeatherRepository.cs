using ECOSaver.Models;

namespace ECOSaver.Repositories
{
    public interface IWeatherRepository
    {
        public List<Weather> GetAll();
        public Weather Add(Weather newWeather);
    }
}
