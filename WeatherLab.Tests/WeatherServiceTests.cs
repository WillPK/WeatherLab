using NUnit.Framework;
using System.Threading.Tasks;
using WeatherLab.Model;

namespace WeatherLab.Tests
{   
    [TestFixture]
    public class WeatherServiceTests
    {
        WeatherService _weatherService;        

        [SetUp]
        public void SetUp()
        {   
            // no mocking, it's end to end test
            _weatherService = new WeatherService(new ConfigManagerWrapper());
        }

        [TestCase("London")]
        [TestCase("Oxford")]
        public async Task ShouldReturnWeatherDataFor(string city)
        {
            var result = await _weatherService.Get5DayForcast(city);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(result));            
        }
    }
}
