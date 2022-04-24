using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Web.Mappers;

namespace Weather.Services.mappers.Tests
{
    [TestClass()]
    public class TemperatureForecastMapperTests
    {
        [TestMethod()]
        [DataRow(-60)]
        [DataRow(0)]
        public void Map_TemperatureValue_To_Freezing(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Freezing", result);
        }

        [TestMethod()]
        [DataRow(0.1f)]
        [DataRow(5)]
        public void Map_TemperatureValue_To_Bracing(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Bracing", result);
        }

        [TestMethod()]
        [DataRow(5.1f)]
        [DataRow(10)]
        public void Map_TemperatureValue_To_Chilly(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Chilly", result);
        }

        [TestMethod()]
        [DataRow(10.1f)]
        [DataRow(15)]
        public void Map_TemperatureValue_To_Cool(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Cool", result);
        }

        [TestMethod()]
        [DataRow(15.1f)]
        [DataRow(20)]
        public void Map_TemperatureValue_To_Mild(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Mild", result);
        }

        [TestMethod()]
        [DataRow(20.1f)]
        [DataRow(25)]
        public void Map_TemperatureValue_To_Warm(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Warm", result);
        }

        [TestMethod()]
        [DataRow(25.1f)]
        [DataRow(30)]
        public void Map_TemperatureValue_To_Balmy(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Balmy", result);
        }

        [TestMethod()]
        [DataRow(30.1f)]
        [DataRow(35)]
        public void Map_TemperatureValue_To_Hot(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Hot", result);
        }

        [TestMethod()]
        [DataRow(35.1f)]
        [DataRow(40)]
        public void Map_TemperatureValue_To_Sweltering(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Sweltering", result);
        }

        [TestMethod()]
        [DataRow(40.1f)]
        [DataRow(60)]
        public void Map_TemperatureValue_To_Scorching(float temperature)
        {
            // Arrange
            var mapper = new TemperatureForecastMapper();

            // Act
            var result = mapper.MapCelsiusToFeelFormat(temperature);

            // Assert
            Assert.AreEqual("Scorching", result);
        }

    }
}