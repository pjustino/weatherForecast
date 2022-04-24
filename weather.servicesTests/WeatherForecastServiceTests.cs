using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Services.Validators;
using Domain.Converters;
using Weather.Repository.Data;
using Moq;

namespace Weather.Services.Tests
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