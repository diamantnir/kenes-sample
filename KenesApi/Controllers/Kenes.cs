using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using RestSharp;
using KenesApi.Services;
using System.Threading.Tasks;

namespace KenesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Kenes : ControllerBase
    {
        private readonly IHttpRequestService _httpRequestService;
        public Kenes(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        [HttpGet("GetToken")]
        public string GetToken()
        {
            string token = _httpRequestService.GetToken();
            return token;
        }

        [HttpGet("GetOrders")]
        public IActionResult GetOrders(string token)
        {
            string orders = _httpRequestService.GetOrders(token);
            return Ok(orders);
        }

        [HttpGet("OrderDetails")]
        public IActionResult GetOrders(string token,string id)
        {
            string orders = _httpRequestService.GetOrder(token, id);
            return Ok(orders);
        }
    }
}
