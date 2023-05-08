using Microsoft.AspNetCore.Mvc;

namespace ECOSensor.Model
{
    public class WeatherData
    {
        public float? Temperature { get; }
        public int? Humidity { get; }

        public float? WindSpeed { get; }

        public WeatherData(float temperature, int humidity, float windSpeed)
        {
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
        }

        public void TemperatureValidate()
        {
            if (Temperature == null)
            {
                throw new ArgumentNullException();
            }
        }
        public void HumidityValidate()
        {
            if (Humidity == null)
            {
                throw new ArgumentNullException();
            }
        }
        public void WindSpeedValidate()
        {
            if (WindSpeed == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
