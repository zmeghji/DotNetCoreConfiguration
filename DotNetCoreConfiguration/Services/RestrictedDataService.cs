using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreConfiguration.Services
{
    public interface IRestrictedDataService
    {
        string GetData(string authSecret);
    }
    public class RestrictedDataService : IRestrictedDataService
    {
        public string GetData(string authSecret)
        {
            if (authSecret == "8387f100-2606-4277-a4c6-a76e9999640e")
            {
                return "Here is some data";
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}
