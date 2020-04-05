using App.API.Models;
using App.Application.Interfaces;
using App.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace App.API.Controllers
{
    [Route("login")]
    [AllowAnonymous]
    public class LoginController : BaseController
    {
        public ILogginLoggiAppService _logginLoggiAppService { get; set; }

        public LoginController(ILogginLoggiAppService logginLoggiAppService)
        {
            _logginLoggiAppService = logginLoggiAppService;
        }

        /// <summary>
        /// Recupera dados de Clientes e/ou Prospects
        /// </summary>
        /// <param name="login">CPF do cliente</param>
        /// <returns></returns>
        [HttpPost()]
        [SwaggerOperation(
         Summary = "Efetua Login Loggi",
         Description = "",
         OperationId = "",
         Tags = new[] { "Login" }
        )]

        [SwaggerResponse(201, "Executado com sucesso!")]
        [SwaggerResponse(204, "Nenhum dado foi encontrado!")]
        [SwaggerResponse(206, "Carregamento Parcial!")]
        [SwaggerResponse(412, "Erro validado!")]
        [SwaggerResponse(500, "Erro Interno!")]
        [ProducesResponseType(typeof(Login), 200)]
        public async Task<IActionResult> Post([FromBody]Login login)
        {
            try
            {
                var mensagem = _logginLoggiAppService.EfetuarLogin(login);
                if (mensagem.Contains("Syntax Error GraphQL"))
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, mensagem);
                }
                return StatusCode((int)HttpStatusCode.Created, mensagem);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
           
        }
    }
}
