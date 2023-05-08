using Microsoft.AspNetCore.Mvc;

namespace ECOSensor.Model
{
    public class WeatherData
    {
       public float? Temperature { get; }
       public int Humidity { get; }

       public float WindSpeed { get; }

        public WeatherData(float temperature, int humidity, float windSpeed)
        {
            Temperature = temperature;
            Humidity = humidity;
            WindSpeed = windSpeed;
        }

        public void WeatherValidate()
        {
            if (Temperature == null)
            {
                throw new ArgumentNullException();
            }

            if (Humidity == null)
            {
                throw new ArgumentNullException():
            }

            if(WindSpeed == null)
            {
                throw new ArgumentNullException()
            }
        }



    }
}
