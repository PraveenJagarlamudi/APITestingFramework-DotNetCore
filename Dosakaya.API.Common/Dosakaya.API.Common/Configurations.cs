using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Dosakaya.API.Common
{
    class Configurations
    {
        public static IConfigurationRoot Config { get; private set; }

        public static void Init()
        {
            var env = Environment.GetEnvironmentVariable("TEST_ENVIRONMENT") ?? "DEV";
            Config = Config ?? new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddYamlFile("Settings.yaml")
                .AddYamlFile($"Settings.{env}.yml")
                .Build();                
        }
    }
}
