using System.Threading.Tasks;

namespace WeatherLab.Model
{
    public interface IWeatherService
    {
        Task<string> Get5DayForcast(string city);
    }
}