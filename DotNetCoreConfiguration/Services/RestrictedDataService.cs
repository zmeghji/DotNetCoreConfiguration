using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreConfiguration.Services
{
    public interface IRestrictedDataService
    {
        string GetData(string authSecret);
        string GetMoreData(string authSecret);

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

        public string GetMoreData(string authSecret)
        {
            if (authSecret == "608cba3e-4aeb-4bd4-89a1-d1d900e3b9dd")
            {
                return "Here is some more data";
            }
            else
            {
                throw new Exception("Unauthorized");
            }
        }
    }
}
