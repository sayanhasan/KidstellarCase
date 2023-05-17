using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidstellarCase.Persistence
{
    public class Configuration
    {
        private static ConfigurationManager AppSettingsConfig
        {
            get
            {
                var appSettingsJsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/KidstellarCase.Web") ;
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(appSettingsJsonFilePath).AddJsonFile("appsettings.json");
                return configurationManager;
            }
        }
        public static string ConnectionString => AppSettingsConfig.GetConnectionString("MySql");

    }
}
