using Infra.Shared.Extensions;
using Infra.Shared.Helpers;
using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Enums;
using MercadoEletronico.Domain.Models.Pedido;
using MercadoEletronico.Domain.Models.Status;
using System.Collections.Generic;
using Xunit;

namespace MercadoEletronico.UnitTests
{
    public class StatusHelperTest
    {
        public PedidoModel CriarPedidoModel()
        {
            var itens = new List<Item>() {
                new Item(1, "Item A", 10, 1),
                new Item(2, "Item B", 5, 2)
            };

            return new PedidoModel(1, 20, 3, itens);
        }

        public CreateStatusModel CriarStatusModel(Status status, int itensAprovados, decimal valorAprovado, string pedido)
        {
            return new CreateStatusModel
            {
                Status = status.GetDescription(),
                ItensAprovados = itensAprovados,
                ValorAprovado = valorAprovado,
                Pedido = pedido
            };
        }

        [Fact]
        public void SetStatus_Retorna_CODIGO_PEDIDO_INVALIDO()
        {
            var pedidoModel = new PedidoModel(0);
            var createStatusModel = new CreateStatusModel();

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.CodigoPedidoInvalido.GetDescription());
        }

        [Fact]
        public void SetStatus_Retorna_REPROVADO()
        {
            var pedidoModel = CriarPedidoModel();
            var createStatusModel = CriarStatusModel(Status.Reprovado, 3, 20, "123456");

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.Reprovado.GetDescription());
        }

        [Fact]
        public void SetStatus_Retorna_APROVADO()
        {
            var pedidoModel = CriarPedidoModel();
            var createStatusModel = CriarStatusModel(Status.Aprovado, 3, 20, "123456");

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.Aprovado.GetDescription());
        }

        [Fact]
        public void SetStatus_Retorna_APROVADO_VALOR_MENOR()
        {
            var pedidoModel = CriarPedidoModel();
            var createStatusModel = CriarStatusModel(Status.Aprovado, 3, 10, "123456");

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.AprovadoValorMenor.GetDescription());
        }

        [Fact]
        public void SetStatus_Retorna_APROVADO_QUANTIDADE_MENOR()
        {
            var pedidoModel = CriarPedidoModel();
            var createStatusModel = CriarStatusModel(Status.Aprovado, 2, 20, "123456");

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.AprovadoQuantidadeMenor.GetDescription());
        }

        [Fact]
        public void SetStatus_Retorna_APROVADO_VALOR_MAIOR_E_APROVADO_QTD_A_MAIOR()
        {
            var pedidoModel = CriarPedidoModel();
            var createStatusModel = CriarStatusModel(Status.Aprovado, 4, 21, "123456");

            var status = StatusHelper.SetStatus(pedidoModel, createStatusModel);
            Assert.Equal(status[0], Status.AprovadoValorMaior.GetDescription());
            Assert.Equal(status[1], Status.AprovadoQuantidadeMaior.GetDescription());
        }
    }
}
