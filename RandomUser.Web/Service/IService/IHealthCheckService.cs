using RandomUser.Web.Models;
using RandomUser.Web.Models.Dto;

namespace RandomUser.Web.Service.IService
{
    public interface IHealthCheckService
    {
        Task<ResponseDto?> GetHealthCheckInfomationAsync();
    }
}
