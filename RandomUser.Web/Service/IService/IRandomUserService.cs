using RandomUser.Web.Models;
using RandomUser.Web.Models.Dto;

namespace RandomUser.Web.Service.IService
{
    public interface IRandomUserService
    {
        Task<ResponseDto?> GetAllRandumUsersAsync(LoginRequestDto loginRequestDto);
    }
}
