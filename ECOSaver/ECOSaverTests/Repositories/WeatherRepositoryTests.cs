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
            Weather newweather = new Weather() { Temperature = 12.12, Humidity = 54.23, WindSpeed = 35.23 };

            WeatherRepository newweatherRepository = new WeatherRepository();

            Weather weather = newweatherRepository.Add(newweather);

            Assert.IsNotNull(weather);
        }
    }
}