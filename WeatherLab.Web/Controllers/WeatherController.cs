using System.Threading.Tasks;
using System.Web.Http;
using WeatherLab.Model;

namespace WeatherLab.Web.Controllers
{
    public class WeatherController : ApiController
    {
        readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost]
        public async Task<string> Find5DayForcast(string city)
        {
            return await _weatherService.Get5DayForcast(city);
        }
    }
}