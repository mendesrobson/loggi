using App.Domain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface ICriarPedidoLoggiAppService
    {
        JObject CriarPedidos(string apiKey, Pedidos pedidos);
    }
}
