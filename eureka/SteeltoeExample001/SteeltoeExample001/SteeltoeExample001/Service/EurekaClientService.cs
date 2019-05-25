using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Steeltoe.Common.Discovery;

namespace SteeltoeExample001.Service
{

    public interface IEurekaClientService
    {
        Task<string> GetServices();
    }

    public class EurekaClientService : IEurekaClientService
    {
        private DiscoveryHttpClientHandler _handler;
        private ILogger<EurekaClientService> _logger;

        public EurekaClientService(IDiscoveryClient client, ILoggerFactory logFactory = null)
        {
            _handler = new DiscoveryHttpClientHandler(client, logFactory?.CreateLogger<DiscoveryHttpClientHandler>());
            _logger = logFactory?.CreateLogger<EurekaClientService>();
        }


        public Task<string> GetServices()
        {
            var client = new HttpClient(_handler, false);
            var result = client.GetStringAsync("http://EUREKAKCLIENT01/getMember");

            return result;
        }
    }
}
