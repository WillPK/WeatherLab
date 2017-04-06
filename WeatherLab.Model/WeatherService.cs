using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherLab.Model
{
    public class WeatherService : IWeatherService
    {      
        private readonly IConfigManager _configManager;

        public WeatherService(IConfigManager configManager)
        {
            _configManager = configManager;
        }

        public async Task<string> Get5DayForcast(string city)
        {
            var url = string.Format(_configManager.WeatherApiUrlPattern, city);

            var webClient = new HttpClient();

            return await webClient.GetStringAsync(url);
        }
    }
}
