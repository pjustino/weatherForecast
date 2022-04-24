using Domain.Converters;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Exceptions;
using Weather.Services;
using Weather.Web.Mappers;
using Weather.Web.Models;

namespace WeatherForecast.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        private WeatherForecastController getInstance(IWeatherForecastService weatherForecastService) => new WeatherForecastController(
            new Mock<ILogger<WeatherForecastController>>().Object,
            weatherForecastService,
            new TemperatureForecastMapper(),
            new TemperatureConverter()
            );

        private List<WeatherForecastCelsius> GetCelsiusForecastDummyData() => new List<WeatherForecastCelsius>
        {
            new WeatherForecastCelsius
            {
                Temperature = -1.1f,
                Date = System.DateTime.Now.Date
            },
            new WeatherForecastCelsius
            {
                Temperature = -32.5f,
                Date = System.DateTime.Now.Date
            },

        };

        [TestMethod()]
        public async Task Get_WeekForecast_returnSuccessJson()
        {
            // Arrange
            var serviceReturnlist = GetCelsiusForecastDummyData();
            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(m => m.GetWeekForecast()).ReturnsAsync(serviceReturnlist);
            var weatherController = getInstance(weatherForecastService.Object);

            // Act
            var apiResponse = await weatherController.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(apiResponse);
            Assert.AreEqual(200, apiResponse.StatusCode);

            var responseBody = apiResponse.Value as ForecastReportResult;
            Assert.IsNotNull(responseBody);
            Assert.AreEqual(true, responseBody.Success);
            Assert.AreEqual(serviceReturnlist.Count, responseBody.ForecastByDay.Count());
        }

        [TestMethod()]
        public async Task Get_WeekForecast_returnFeelLikeForecast()
        {
            // Arrange
            var testDate = System.DateTime.Now.Date;
            var serviceReturnlist = new List<WeatherForecastCelsius> {
                new WeatherForecastCelsius
                {
                    Temperature = 11.5f,
                    Date = testDate
                },
            };
            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(m => m.GetWeekForecast()).ReturnsAsync(serviceReturnlist);
            var weatherController = getInstance(weatherForecastService.Object);

            // Act
            var apiResponse = await weatherController.Get() as OkObjectResult;

            //Assert
            Assert.IsNotNull(apiResponse);
            var responseBody = apiResponse.Value as ForecastReportResult;
            Assert.IsNotNull(responseBody);
            Assert.IsNotNull(responseBody.ForecastByDay);
            Assert.AreEqual(responseBody.ForecastByDay.ElementAt(0).TemperatureFeel, "Cool");
            Assert.AreEqual(responseBody.ForecastByDay.ElementAt(0).Date, testDate.ToShortDateString());
        }

        [TestMethod()]
        public async Task Add_FahrenheitForecast_ConvertsValueToService()
        {
            // Arrange
            var temperatureServiceParam = 0f;
            var newForecast = new ForecastInput
            {
                Temperature = 102.2f,
                Date = DateTime.Now.Date,
                unit = TemperatureUnit.FAHRENHEIT
            };

            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Callback( ( WeatherForecastCelsius forecast) => {
                    temperatureServiceParam = forecast.Temperature;
                });
            var weatherController = getInstance(weatherForecastService.Object);

            //Act
            var apiResponse = await weatherController.Post(newForecast) as OkObjectResult;

            // Assert
            Assert.AreEqual(39, temperatureServiceParam);
        }

        [TestMethod()]
        public async Task Add_FahrenheitForecast_ReturnsSuccessJson()
        {
            // Arrange
            var newForecast = new ForecastInput
            {
                Temperature = 102.2f,
                Date = DateTime.Now.Date
            };

            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Returns(Task.CompletedTask);
            var weatherController = getInstance(weatherForecastService.Object);

            //Act
            var apiResponse = await weatherController.Post(newForecast) as OkObjectResult;

            // Assert
            Assert.IsNotNull(apiResponse);
            Assert.AreEqual(200, apiResponse.StatusCode);
            var responseBody = apiResponse.Value as ForecastBaseResult;
            Assert.IsNotNull(responseBody);
            Assert.IsTrue(responseBody.Success);
        }

        [TestMethod()]
        public async Task Add_Forecast_ReturnsFailJson()
        {
            // Arrange
            var newForecast = new ForecastInput
            {
                Temperature = 102.2f,
                Date = DateTime.Now.Date
            };

            var weatherForecastService = new Mock<IWeatherForecastService>();
            weatherForecastService.Setup(m => m.AddForecastByDay(It.IsAny<WeatherForecastCelsius>()))
                .Throws(new ForecastInputException());
            var weatherController = getInstance(weatherForecastService.Object);

            //Act
            var apiResponse = await weatherController.Post(newForecast) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(apiResponse);
            Assert.AreEqual(400, apiResponse.StatusCode);
            var responseBody = apiResponse.Value as ForecastBaseResult;
            Assert.IsNotNull(responseBody);
            Assert.IsFalse(responseBody.Success);
            Assert.IsTrue(responseBody.ErrorMessage.Length > 0);
        }
    }
}