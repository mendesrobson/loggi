using App.API.Models;
using App.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace App.API.Controllers
{
    [Route("v1/health/")]
    [AllowAnonymous]
    public class HealthController : BaseController
    {
        private readonly IHealthCheckService _healthCheckService;

        public HealthController(IHealthCheckService healthCheckService)
        {
            _healthCheckService = healthCheckService;
        }

        [HttpGet("live")]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult Live()
        {
            return Ok(string.Empty);
        }

        [HttpGet("read")]
        [SwaggerOperation(
        Summary = "EndPoint para Devops"
        )]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        [SwaggerResponse(500)]
        public IActionResult Read()
        {
            string result = _healthCheckService.Readings();
            if (result.IndexOf("Success") != -1)
                return StatusCode((int)HttpStatusCode.Accepted);

            return BadRequest(result);
        }

    }
}