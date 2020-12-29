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

            var rules = new Dictionary<string, bool>
            {
                // Status PEDIDO INVÁLIDO
                { Status.CodigoPedidoInvalido.GetDescription(), pedido.Id == 0 },

                // Status REPROVADO
                { Status.Reprovado.GetDescription(), statusModel.Status == Status.Reprovado.GetDescription() },

                // Status APROVADO
                {
                    Status.Aprovado.GetDescription(),
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados == pedido.QuantidadeItensPedido
                && statusModel.ValorAprovado == pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoValorMenor.GetDescription(),
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ValorAprovado < pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoQuantidadeMenor.GetDescription(),
                    statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados < pedido.QuantidadeItensPedido
                },
                {
                    Status.AprovadoValorMaior.GetDescription(),
                    pedido.Id > 0 && statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ValorAprovado > pedido.ValorTotalPedido
                },
                {
                    Status.AprovadoQuantidadeMaior.GetDescription(),
                    pedido.Id > 0 && statusModel.Status == Status.Aprovado.GetDescription()
                && statusModel.ItensAprovados > pedido.QuantidadeItensPedido
                }
            };

            return rules.Where(it => it.Value == true).Select(it => it.Key.ToString()).ToList();
        }
    }
}
