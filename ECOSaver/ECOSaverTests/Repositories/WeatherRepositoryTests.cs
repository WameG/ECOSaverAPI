using Microsoft.VisualStudio.TestTools.UnitTesting;
using ECOSaver.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOSaver.Models;

namespace ECOSaver.Repositories.Tests
{
    [TestClass()]
    public class WeatherRepositoryTests
    {

        [TestMethod()]
        public void GetAllTest()
        {
            WeatherRepository repository = new WeatherRepository();

            List<Weather> weathers = repository.GetAll();

            Assert.IsNotNull(weathers);
        }

        [TestMethod()]
        public void AddTest()
        {

            double temperature = 40;
            double humidity = 30;
            DateTime date = DateTime.Now;

            Weather newWeather = new Weather() { Temperature = temperature, Humidity = humidity, Date = date };

            WeatherRepository repository = new WeatherRepository();

            Weather addedWeather = repository.Add(newWeather);

            Assert.IsNotNull(addedWeather);
            Assert.AreEqual(temperature, addedWeather.Temperature);
            Assert.AreEqual(humidity, addedWeather.Humidity);
            Assert.AreEqual(date, addedWeather.Date);

        }
    }
}