namespace ECOSaver.Models
{
    public class Weather
    {
        public string? Temperature { get; set; }
        public string? Humidity { get; set; }

        public string? WindSpeed { get; set; }

        public void ValidateTemperature()
        {
            if(Temperature == null) {
                throw new ArgumentNullException();
            }
        }

        public void ValidateHumidity()
        {
            if(Humidity == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void ValidateWindSpeed()
        {
            if (WindSpeed == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void Validate()
        {
            ValidateTemperature();
            ValidateHumidity();
            ValidateWindSpeed();
        }
    }
}
