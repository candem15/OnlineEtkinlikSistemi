﻿using Microsoft.Extensions.Configuration;

namespace OES.API.Persistence
{
    static class Configuration
    {
        static public string ConnectionStringDockerPg
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/OES.API.WebApi/"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("DockerPostgreSQL");
            }
        }
    }
}
