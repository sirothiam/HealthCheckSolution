using AutoMapper;
using Health.Services.HealthAPI.Models.Dto;
using Health.Services.HealthAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace Health.Services.HealthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomUserController : ControllerBase
    {
        protected ResponseDto _response;
        //private IMapper _mapper;
        //private readonly IConfiguration _configuration;
        private readonly IBaseService _baseservice;
        private readonly HealthCheckService _healthCheckService;

        public RandomUserController(IBaseService baseService, HealthCheckService healthCheckService)
        {
            this._response = new ResponseDto();
            //this._mapper = mapper;
            //this._configuration = configuration;
            _healthCheckService = healthCheckService;
            _baseservice = baseService;
        }

        [HttpGet("HealthCheck")]
        public async Task<IActionResult> GetHelthCheckInfomation()
        {
            //var healthCheckStatus = await _baseservice.SendHeathCheckAsync();
            //var status = healthCheckStatus.Description;
            //return Ok(status);
            try 
            {
                HealthReport healthReport = await _healthCheckService.CheckHealthAsync();
                _response.Result = healthReport.Status.ToString();
               
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task <IActionResult>FetchUserInformation([FromBody] LoginRequestDto model)
        {
            try
            {
                if (model == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Username or password is incorrect";
                    return BadRequest(_response);
                }
                if (model.UserName == "admin" && model.Password == "admin@123")
                {
                    var randomUser = await _baseservice.SendAsync();
                    _response.Result = randomUser;
                }
                else 
                {
                    _response.IsSuccess = false;
                    _response.Message = "Username or password is incorrect";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            //turn _response;
            return Ok(_response);
        }
    }
}
