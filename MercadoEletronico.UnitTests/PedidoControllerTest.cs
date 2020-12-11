using MercadoEletronico.Application.Controllers;
using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Domain.Models.Pedido;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MercadoEletronico.UnitTests
{
    public class PedidoControllerTest
    {
        [Fact]
        public void Register_Retorna_CreatedResult()
        {
            var itens = new List<Item>() {
                new Item(1, "Item A", 10, 1),
                new Item(2, "Item B", 5, 2)
            };

            var createPedidoModel = new CreatePedidoModel()
            {
                Id = 1,
                Itens  = itens,
                Pedido = "123456",
                PedidoExistente = false
            };

            var mock = new Mock<IServicePedido>();
            mock.Setup(it => it.Insert(createPedidoModel)).Returns(new PedidoModel(0));

            var pedidoController = new PedidoController(mock.Object);

            var result = pedidoController.Register(createPedidoModel) as CreatedResult;

            Assert.Equal(201, result.StatusCode);
        }
    }
}
