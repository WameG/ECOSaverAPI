namespace ECOSensor.Model
{
    public class WeatherData
    {
       public float Temperature { get; }
       public int Humidity { get; }

       public float Speed { get; }

        public WeatherData(float temperature, int humidity, float speed)
        {
            Temperature = temperature;
            Humidity = humidity;
            Speed = speed;
        }




    }
}
