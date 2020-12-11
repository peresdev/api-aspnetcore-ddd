using Infra.Shared.Extensions;
using MercadoEletronico.Application.Controllers;
using MercadoEletronico.Domain.Enums;
using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Domain.Models.Pedido;
using MercadoEletronico.Domain.Models.Status;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MercadoEletronico.UnitTests
{
    public class StatusControllerTest
    {
        [Fact]
        public void Register_Retorna_CreatedResult()
        {
            var createStatusModel = new CreateStatusModel()
            {
                Status = Status.Aprovado.GetDescription(),
                Pedido = "123456",
                ItensAprovados = 3,
                ValorAprovado = 20
            };

            var mock = new Mock<IServicePedido>();
            mock.Setup(it => it.RecoverByPedido("123456")).Returns(new PedidoModel(0));

            var statusController = new StatusController(mock.Object);

            var result = statusController.Register(createStatusModel) as CreatedResult;

            Assert.Equal(201, result.StatusCode);
        }
    }
}
