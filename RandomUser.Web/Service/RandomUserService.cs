using RandomUser.Web.Models;
using RandomUser.Web.Models.Dto;
using RandomUser.Web.Service.IService;
using RandomUser.Web.Utility;

namespace RandomUser.Web.Service
{
    public class RandomUserService : IRandomUserService
    {
        private readonly IBaseService _baseService;
        public RandomUserService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> GetAllRandumUsersAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                //ApiType = SD.ApiType.GET,
                //Url = SD.RandomUserAPIBase + "/api/RandomUser"
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.RandomUserAPIBase + "/api/RandomUser"
            });
        }
    }
}
