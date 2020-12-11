using Infra.Shared.Extensions;
using MercadoEletronico.Domain.Enums;
using MercadoEletronico.Domain.Models.Pedido;
using MercadoEletronico.Domain.Models.Status;
using System.Collections.Generic;

namespace Infra.Shared.Helpers
{
    public static class StatusHelper
    {
        public static List<string> SetStatus(PedidoModel pedido, CreateStatusModel statusModel) {

            var statuses = new List<string>();

            // Status PEDIDO INVÁLIDO
            if(pedido.Id == 0)
            {
                statuses.Add(Status.CodigoPedidoInvalido.GetDescription());
                return statuses;
            }

            // Status REPROVADO
            if (statusModel.Status == Status.Reprovado.GetDescription())
            {
                statuses.Add(Status.Reprovado.GetDescription());
                return statuses;
            }

            // Status APROVADO
            if (statusModel.Status == Status.Aprovado.GetDescription())
            {
                if (statusModel.ItensAprovados == pedido.QuantidadeItensPedido &&
                    statusModel.ValorAprovado == pedido.ValorTotalPedido)
                {
                    statuses.Add(Status.Aprovado.GetDescription());
                }

                if (statusModel.ValorAprovado < pedido.ValorTotalPedido)
                {
                    statuses.Add(Status.AprovadoValorMenor.GetDescription());
                }

                if (statusModel.ItensAprovados < pedido.QuantidadeItensPedido)
                {
                    statuses.Add(Status.AprovadoQuantidadeMenor.GetDescription());
                }

                if (statusModel.ValorAprovado > pedido.ValorTotalPedido)
                {
                    statuses.Add(Status.AprovadoValorMaior.GetDescription());
                }

                if (statusModel.ItensAprovados > pedido.QuantidadeItensPedido)
                {
                    statuses.Add(Status.AprovadoQuantidadeMaior.GetDescription());
                }
            }

            return statuses;
        }
    }
}
