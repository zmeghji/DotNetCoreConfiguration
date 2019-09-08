using DotNetCoreConfiguration.ConfigurationSources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreConfiguration.Providers
{
    public class CsvConfigurationProvider : FileConfigurationProvider
    {
        public CsvConfigurationProvider(CsvConfigurationSource source) : base(source) { }
        public override void Load(Stream stream)
        {
            try
            {
                var streamReader = new StreamReader(stream);
                Data = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    var key = line.Split(",")[0];
                    var value = line.Split(",")[1];
                    Data[key] = value;
                }
            }
            catch
            {
                throw new Exception("Failed to read from csv config source");
            }
        }
    }
}
