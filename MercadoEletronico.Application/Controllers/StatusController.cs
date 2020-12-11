using Infra.Shared.Helpers;
using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Domain.Models.Status;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MercadoEletronico.Application.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IServicePedido _servicePedido;

        public StatusController(IServicePedido servicePedido) =>
            _servicePedido = servicePedido;


        [HttpPost]
        public IActionResult Register([FromBody] CreateStatusModel statusModel)
        {
            try
            {
                var pedido = _servicePedido.RecoverByPedido(statusModel.Pedido);

                var payload = new
                {
                    pedido = statusModel.Pedido,
                    status = StatusHelper.SetStatus(pedido, statusModel)
                };

                return Created($"/api/status", payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
