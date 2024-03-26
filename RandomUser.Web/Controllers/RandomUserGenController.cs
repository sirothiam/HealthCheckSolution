using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RandomUser.Web.Models;
using RandomUser.Web.Models.Dto;
using RandomUser.Web.Service.IService;
using System.Collections.Generic;

namespace RandomUser.Web.Controllers
{
    public class RandomUserGenController : Controller
    {
        private readonly IRandomUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IHealthCheckService _healthCheckService;
        public RandomUserGenController(IRandomUserService userService, IConfiguration _config, IHealthCheckService healthCheckService)
        {
            _userService = userService;
            _configuration = _config;
            _healthCheckService = healthCheckService;
        }
        /// <summary>
        /// Function to fetch user data randomly.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            RootObject? rootObject = new();
            LoginRequestDto loginRequestDto = new LoginRequestDto()
            {
                UserName = _configuration.GetValue<string>("LoginInfo:UserName"),
                Password = _configuration.GetValue<string>("LoginInfo:Password")

            };
            ResponseDto? response = await _userService.GetAllRandumUsersAsync(loginRequestDto);
            if (response != null && response.IsSuccess)
            {
                rootObject = JsonConvert.DeserializeObject<RootObject>(Convert.ToString(response.Result));
                TempData["success"] = "User data fetched successfully";

            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(rootObject);
        }
        /// <summary>
        /// Function to check the status of running service once start.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> HealthCheck()
        {
            HealthStatus? healthStatus = new();
            ResponseDto? response = await _healthCheckService.GetHealthCheckInfomationAsync();
            if (response != null && response.IsSuccess)
            {
                //healthStatus = JsonConvert.DeserializeObject<HealthStatus>(Convert.ToString(response.Result));
                healthStatus.status = response.Result.ToString();
                TempData["success"] = "Healty";

            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(healthStatus);
        }
    }
}
