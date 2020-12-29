using Infra.Shared.Extensions;
using MercadoEletronico.Domain.Enums;
using MercadoEletronico.Domain.Models.Pedido;
using MercadoEletronico.Domain.Models.Status;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Shared.Helpers
{
    public static class StatusHelper
    {
        public static List<string> SetStatus(PedidoModel pedido, CreateStatusModel statusModel) {

            var rules = new Dictionary<Status, bool>
            {
                // Status PEDIDO INVÁLIDO
                { Status.CodigoPedidoInvalido, pedido.Id == 0 },

                // Status REPROVADO
                { Status.Reprovado, statusModel.Status == Status.Reprovado.GetDescription() },

                // Status APROVADO
                {
                    Status.Aprovado,
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados == pedido.QuantidadeItensPedido
                && statusModel.ValorAprovado == pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoValorMenor,
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ValorAprovado < pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoQuantidadeMenor,
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados < pedido.QuantidadeItensPedido
                },
                {
                    Status.AprovadoValorMaior,
                    pedido.Id > 0 && statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ValorAprovado > pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoQuantidadeMaior,
                    pedido.Id > 0 && statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados > pedido.QuantidadeItensPedido
                }
            };

            return rules.Where(it => it.Value == true).Select(it => it.Key.GetDescription().ToString()).ToList();
        }
    }
}
