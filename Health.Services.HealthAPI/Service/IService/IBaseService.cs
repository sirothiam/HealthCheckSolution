using Health.Services.HealthAPI.Models;
using Health.Services.HealthAPI.Models.Dto;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Health.Services.HealthAPI.Service.IService
{
    public interface IBaseService
    {
        Task<RootObject?> SendAsync();
        Task<HealthCheckResult> SendHeathCheckAsync();
    }
}
