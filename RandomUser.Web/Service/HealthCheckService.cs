using RandomUser.Web.Models;
using RandomUser.Web.Service.IService;
using RandomUser.Web.Utility;

namespace RandomUser.Web.Service
{
    public class HealthCheckService : IHealthCheckService
    {
        private readonly IBaseService _baseService;
        public HealthCheckService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetHealthCheckInfomationAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                //ApiType = SD.ApiType.GET,
                //Url = SD.RandomUserAPIBase + "/api/RandomUser"
                ApiType = SD.ApiType.GET,
                Url = SD.RandomUserAPIBase + "/api/RandomUser/HealthCheck"
            });
        }
    }
}
