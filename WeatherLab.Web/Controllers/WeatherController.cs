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
    public async Task<IHttpActionResult> Find5DayForcast(string city)
    {
      try
      {
          return Json(await _weatherService.Get5DayForcast(city));
      }
      catch
      {
        return Json(string.Empty);
      }
    }
  }
}