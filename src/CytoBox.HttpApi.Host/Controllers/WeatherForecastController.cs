using CytoBox.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CytoBox.HttpApi.Host.Controllers
{
    /// <summary>
    /// 默认测试控制器
    /// </summary>
    [ApiController]
    [Route("controller")]
    public class WeatherForecastController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public WeatherForecastController() { }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Get 测试API
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Gets")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Get 测试API
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("login")]
        public ResponseData<Login> Login([Required][FromQuery] string userName, [Required][FromQuery] string password)
        {
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                return new ResponseData<Login>
                {
                    Code = "200",
                    Message = "登录成功",
                    Data = new Login
                    {
                        UserName = userName,
                        Password = password,
                        Token = "123123"
                    }
                };
            }
            return new ResponseData<Login>
            {
                Code = "201",
                Message = "登录失败",
                Data = new Login
                {
                    UserName = userName,
                    Password = password,
                    Token = string.Empty
                }
            };
        }
    }
}
