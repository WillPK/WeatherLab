using System.Configuration;

namespace WeatherLab.Model
{
    public class ConfigManagerWrapper : IConfigManager
    {
        public string WeatherApiUrlPattern => ConfigurationManager.AppSettings["WeatherApiUrlPattern"];
    }
}
