using Moq;
using UnitTestingExample;
using UnitTestingExample.Controllers;
using Microsoft.Extensions.Logging;


namespace test
{
    public class WeatherControllerTests
    {
        private readonly WeatherForecastController _controller;

        public WeatherControllerTests()
        {
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            _controller = new WeatherForecastController(loggerMock.Object);
        }

        [Fact]
        public void Get_ShouldReturnWeatherForecasts()
        {
            var result = _controller.Get();

            var forecasts = Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(result);
            Assert.Equal(5, forecasts.Count()); 
        }

        [Fact]
        public void Get_ShouldReturnWeatherForecast()
        {
            var result = _controller.Get(1);

            var forecast = Assert.IsType<WeatherForecast>(result);
            Assert.True(forecast == null);
        }
    }
}
