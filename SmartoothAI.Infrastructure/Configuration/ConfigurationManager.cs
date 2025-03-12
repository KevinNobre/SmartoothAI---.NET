using Microsoft.Extensions.Configuration;

namespace SmartoothAI.Infrastructure.Configuration
{
    public class AppConfigurationManager 
    {
        private static AppConfigurationManager? _instance;
        private static readonly object _lock = new object();
        private readonly IConfiguration _configuration;

        private AppConfigurationManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static AppConfigurationManager GetInstance(IConfiguration configuration)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AppConfigurationManager(configuration);
                    }
                }
            }
            return _instance;
        }

        public string GetSetting(string key)
        {
            return _configuration[key] ?? string.Empty;
        }
    }
}
