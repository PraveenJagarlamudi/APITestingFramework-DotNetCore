using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APITest
{
    class ConfigureServices
    {
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            // Configure Settings
            services.AddOptions();
            
            // Add Dependencies

            // NOTE: This line is essential so that Microsoft.Extensions.DependencyInjection knows
            // about the SpecFlow bindings (something normally BoDi does automatically).
            foreach (var type in typeof(ConfigureServices).Assembly.GetTypes().Where(t => Attribute.IsDefined(t, typeof(BindingAttribute))))
            {
                services.AddSingleton(type);
            }

            return services;
        }
    }
}
