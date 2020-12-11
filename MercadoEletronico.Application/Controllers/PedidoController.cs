using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Domain.Models.Pedido;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MercadoEletronico.Application.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IServicePedido _servicePedido;

        public PedidoController(IServicePedido servicePedido) =>
            _servicePedido = servicePedido;

        [HttpPost]
        public IActionResult Register([FromBody] CreatePedidoModel pedidoModel)
        {
            try
            {
                pedidoModel.PedidoExistente = _servicePedido.RecoverByPedido(pedidoModel.Pedido)?.Id > 0;

                var pedido = _servicePedido.Insert(pedidoModel);

                return Created($"/api/pedido/{pedido?.Id}", pedido?.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
