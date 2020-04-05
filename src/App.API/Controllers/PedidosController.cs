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
    [Route("criacao-de-pedido")]
    [AllowAnonymous]
    public class PedidosController: BaseController
    {
        public ICriarPedidoLoggiAppService _criarPedidoLoggiAppService { get; set; }
        public PedidosController(ICriarPedidoLoggiAppService criarPedidoLoggiAppService)
        {
            _criarPedidoLoggiAppService = criarPedidoLoggiAppService;
        }

        /// <summary>
        /// Recupera dados de Clientes e/ou Prospects
        /// </summary>
        /// <param name="login">CPF do cliente</param>
        /// <returns></returns>
        [HttpPost()]
        [SwaggerOperation(
         Summary = "Criar Pedidos Loggi",
         Description = "",
         OperationId = "",
         Tags = new[] { "Pedidos" }
        )]

        [SwaggerResponse(201, "Executado com sucesso!")]
        [SwaggerResponse(204, "Nenhum dado foi encontrado!")]
        [SwaggerResponse(206, "Carregamento Parcial!")]
        [SwaggerResponse(412, "Erro validado!")]
        [SwaggerResponse(500, "Erro Interno!")]
       
       // [ProducesResponseType(typeof(Pedidos), 201)]
        public async Task<IActionResult> Post([FromHeader(Name = "apiKey")]string apiKey,[FromBody]Pedidos pedidos)
        {
            try
            {
                var mensagem = _criarPedidoLoggiAppService.CriarPedidos(apiKey, pedidos);
                //if (mensagem.Contains("Syntax Error GraphQL"))
                //{
                    return StatusCode((int)HttpStatusCode.InternalServerError, mensagem);
                //}
                //return StatusCode((int)HttpStatusCode.Created, mensagem);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

    }
}
