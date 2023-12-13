using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebTestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IpController : ControllerBase
    {
        public IpController(HttpClient httpClient, IUnitOfWork unitOfWork) 
        {
            _httpClient = httpClient;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetIpInfo(string ipAddress)
        {
            var response = await _httpClient.GetAsync($"https://ipinfo.io/{ipAddress}/geo");

            var ipAddressIsNotExist = _unitOfWork.IpAddressRepository.GetById(ipAddress) == null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var ipAddressInfo = JsonConvert.DeserializeObject<IpAddress>(content);

                if (ipAddressIsNotExist)
                {
                    _unitOfWork.IpAddressRepository.Add(ipAddressInfo);
                    _unitOfWork.Save();
                }

                return Content(content, CONTENT_TYPE);
            }
            else
            {
                return BadRequest(response);
            }
        }

        private readonly HttpClient _httpClient;
        private readonly IUnitOfWork _unitOfWork;

        private const string CONTENT_TYPE = "application/json";
    }
}
