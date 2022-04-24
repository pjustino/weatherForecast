using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Services.Validators;
using Domain.Converters;
using Weather.Repository.Data;
using Moq;
using Domain.Models;
using Weather.Domain.Exceptions;

namespace Weather.Services.Tests
{
    [TestClass()]
    public class WeatherForecastServiceTests
    {
        private IWeatherForecastService getInstance(IWeatherForecastRepository repository) =>
            new WeatherForecastService(new TemperatureValidator(new TemperatureConverter()), repository);

        [TestMethod()]
        public async Task Add_ValidForecast_ReturnsSuccess()
        {
            // Arrange
            var repositoryMock = new Mock<IWeatherForecastRepository>();
            repositoryMock.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Returns(Task.CompletedTask);

            var weatherService = getInstance(repositoryMock.Object);
            var testForecast = new WeatherForecastCelsius
            {
                Date = DateTime.Now.Date,
                Temperature = (float)TemperatureRangeCelsius.MIN
            };

            // Act
            await weatherService.AddForecastByDay(testForecast);

            repositoryMock.Verify(q => q.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()), Times.Once);
        }

        [TestMethod()]
        public async Task Add_InvalidDateForecast_ThrowsException()
        {
            // Arrange
            var repository = new Mock<IWeatherForecastRepository>();
            repository.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Returns(Task.CompletedTask);

            var weatherService = getInstance(repository.Object);
            var testForecast = new WeatherForecastCelsius
            {
                Date = DateTime.Now.AddDays(-1).Date,
                Temperature = (float)TemperatureRangeCelsius.MIN
            };

            await Assert.ThrowsExceptionAsync<ForecastInputException>(async () => await weatherService.AddForecastByDay(testForecast));
        }

        [TestMethod()]
        public async Task Add_BellowThresholdTemperatureForecast_ThrowsException()
        {
            // Arrange
            var repository = new Mock<IWeatherForecastRepository>();
            repository.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Returns(Task.CompletedTask);

            var weatherService = getInstance(repository.Object);
            var testForecast = new WeatherForecastCelsius
            {
                Date = DateTime.Now.AddDays(1).Date,
                Temperature = (float)TemperatureRangeCelsius.MIN - 1
            };

            await Assert.ThrowsExceptionAsync<ForecastInputException>(async () => await weatherService.AddForecastByDay(testForecast));
        }

        [TestMethod()]
        public async Task Add_AboveThresholdTemperatureForecast_ThrowsException()
        {
            // Arrange
            var repository = new Mock<IWeatherForecastRepository>();
            repository.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Returns(Task.CompletedTask);

            var weatherService = getInstance(repository.Object);
            var testForecast = new WeatherForecastCelsius
            {
                Date = DateTime.Now.AddDays(1).Date,
                Temperature = (float)TemperatureRangeCelsius.MAX + 1
            };

            await Assert.ThrowsExceptionAsync<ForecastInputException>(async () => await weatherService.AddForecastByDay(testForecast));
        }

        [TestMethod()]
        public async Task Get_WeekForecast_ReturnsForecastList()
        {
            // Arrange
            var reporReturnForecast = new List<WeatherForecastCelsius>
            {
                new WeatherForecastCelsius
                {
                    Date = DateTime.Now,
                    Temperature = (float)TemperatureRangeCelsius.MAX
                },
                                new WeatherForecastCelsius
                {
                    Date = DateTime.Now,
                    Temperature = (float)TemperatureRangeCelsius.MIN
                }
            };
             var repository = new Mock<IWeatherForecastRepository>();
            repository.Setup(m => m.GetWeekForecast())
                .ReturnsAsync(reporReturnForecast);

            var weatherService = getInstance(repository.Object);

            // Act
            var returnList = await weatherService.GetWeekForecast();

            //Assert
            Assert.AreEqual(reporReturnForecast, returnList);
            Assert.IsTrue(returnList.Count() == 2);

        }
    }
}