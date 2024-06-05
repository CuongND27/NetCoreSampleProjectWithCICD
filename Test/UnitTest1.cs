using CICDTest.Controllers;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Get_ShouldReturnFiveWeatherForecasts()
        {
            // Arrange
            var service = new WeatherForecastController(null);

            // Act
            var result = service.Get();

            // Assert
            Assert.Equal(10, result.Count());
        }

        [Fact]
        public void Get_ShouldReturnForecastsForConsecutiveDays()
        {
            // Arrange
            var service = new WeatherForecastController(null);
            var today = DateOnly.FromDateTime(DateTime.Now);

            // Act
            var result = service.Get().ToList();

            // Assert
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(today.AddDays(i + 1), result[i].Date);
            }
        }

        [Fact]
        public void Get_ShouldReturnForecastsWithValidSummaries()
        {
            // Arrange
            var service = new WeatherForecastController(null);
            var validSummaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            // Act
            var result = service.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.Contains(forecast.Summary, validSummaries);
            }
        }

        [Fact]
        public void Get_ShouldReturnForecastsWithValidTemperatureRange()
        {
            // Arrange
            var service = new WeatherForecastController(null);

            // Act
            var result = service.Get();

            // Assert
            foreach (var forecast in result)
            {
                Assert.InRange(forecast.TemperatureC, -20, 55);
            }
        }
    }
}