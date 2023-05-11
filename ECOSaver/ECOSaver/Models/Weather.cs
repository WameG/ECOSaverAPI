namespace ECOSaver.Models
{
    public class Weather
    {
        public int? Id { get; set; }
        public double? Temperature { get; set; }
        public double? Humidity { get; set; }
        public DateTime? Date { get; set; }

        public void ValidateId()
        {
            if(Id == null)
            {
                throw new ArgumentException();
            }
        }

        public void ValidateTemperature()
        {
            if(Temperature == null) {
                throw new ArgumentNullException();
            }

            if(Temperature.GetType() !=  typeof(double))
            {
                throw new ArgumentException();
            }

            if(Temperature < -88 || Temperature > 58 )
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateHumidity()
        {
            if(Humidity == null)
            {
                throw new ArgumentNullException();
            }

            if (Humidity.GetType() != typeof(double))
            {
                throw new ArgumentException();
            }

            if (Humidity < 0 || Humidity > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void ValidateDate()
        {
            if(Date == null)
            {
                throw new ArgumentNullException();
            }

            if (Date.GetType() != typeof(DateTime))
            {
                throw new ArgumentException();
            }

            if(Date == DateTime.Today.AddDays(1))
            {
                throw new ArgumentException();
            }

            if(Date == DateTime.Today.AddDays(-1))
            {
                throw new ArgumentException();
            }
        }
        public void Validate()
        {
            ValidateId();
            ValidateTemperature();
            ValidateHumidity();
            ValidateDate();
        }
    }
}
