using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteeltoeWithHttpClientFactory.Service
{
    public interface ITeamService
    {
        Task<string> GetInfo();
    }

    public class TeamService : ITeamService
    {
        private readonly HttpClient _httpClient;

        public TeamService(   HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetInfo()
        {
            var result = await _httpClient.GetStringAsync("");
            return result;
        }
    }
}