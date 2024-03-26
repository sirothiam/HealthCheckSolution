using Health.Services.HealthAPI.Models.Dto;
using Health.Services.HealthAPI.Service.IService;
using Newtonsoft.Json;
using System.Net;
using Health.Services.HealthAPI.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Health.Services.HealthAPI.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<RootObject?> SendAsync()
        {

            HttpClient client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://randomuser.me/api/");
            var stringResult = await response.Content.ReadAsStringAsync();
            var rootObject = JsonConvert.DeserializeObject<RootObject>(stringResult);
            return rootObject;
            
        }

        public async Task<HealthCheckResult> SendHeathCheckAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:7001/api/health");
            if (response.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy($"Remote endpoints is healthy.");
            }
            return HealthCheckResult.Unhealthy("Remote endpoint is unhealthy");
        }
    }
    
}
