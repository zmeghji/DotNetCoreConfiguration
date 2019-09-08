using DotNetCoreConfiguration.Providers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreConfiguration.ConfigurationSources
{
    public class CsvConfigurationSource : FileConfigurationSource
    {
        public CsvConfigurationSource()
        {
            ReloadOnChange = true;
            Optional = true;
            FileProvider = null;
        }
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new CsvConfigurationProvider(this);
        }
    }
}
