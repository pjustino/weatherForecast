using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Converters.Tests
{
    [TestClass()]
    public class TemperatureConverterTests
    {
        [TestMethod()]
        public void Convert_Fahrenheit_To_Celsius_GetCorrectValue()
        {
            // Arrange
            var converter = new TemperatureConverter();

            // Act
            var celsiusValue = converter.ToCelsius(102.2f, Models.TemperatureUnit.FAHRENHEIT);
            // Assert
            Assert.AreEqual(39, celsiusValue);
        }
    }
}