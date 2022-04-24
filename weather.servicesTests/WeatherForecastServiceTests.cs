using Microsoft.VisualStudio.TestTools.UnitTesting;
using weather.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weather.services.Validators;
using Domain.Converters;
using weather.repository.Repository;
using Moq;

namespace weather.services.Tests
{
    [TestClass()]
    public class WeatherForecastServiceTests
    {
        [TestMethod()]
        public void AddForecastTest()
        {
            // Arrange
            var repository = new Mock<IWeatherForecastRepository>();
            var weatherService = new WeatherForecastService(new TemperatureValidator( new TemperatureConverter()), repository.Object);

            // Act

            //Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void GetWeeklyForecastTest()
        {
            Assert.Fail();
        }
    }
}