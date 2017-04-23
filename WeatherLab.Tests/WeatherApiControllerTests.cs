using System.Net.Http;
using Moq;
using NUnit.Framework;
using WeatherLab.Model;
using WeatherLab.Web.Controllers;
using System.Threading.Tasks;

namespace WeatherLab.Tests
{   
    [TestFixture]
    public class WeatherApiControllerTests
    {
        WeatherController _weatherApiController;
        Mock<IWeatherService> _weatherService;

        [SetUp]
        public void SetUp()
        {
            _weatherService = new Mock<IWeatherService>();
            _weatherApiController = new WeatherController(_weatherService.Object);
        }

        [TestCase("London")]
        public async Task ShouldReturnWeatherDataFor(string city)
        {
            var response = "json data from API";

            _weatherService.Setup(s => s.Get5DayForcast(city)).ReturnsAsync(response);

            var result = await _weatherApiController.Find5DayForcast(city);

            Assert.AreEqual(response, result);
        }

        [Test]
        public async Task ShouldReturnEmptyStringWhenWeatherServiceThrowsException()
        {
            var city = "anything";

            _weatherService.Setup(s => s.Get5DayForcast(city)).Throws<HttpRequestException>();

            var result = await _weatherApiController.Find5DayForcast(city);

            Assert.IsEmpty(result);
        }
    }
}
