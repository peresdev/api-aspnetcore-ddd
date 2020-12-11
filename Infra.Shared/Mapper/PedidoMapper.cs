using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Models.Pedido;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Shared.Mapper
{
    public static class PedidoMapper
    {
        public static Pedido ConvertToPedidoEntity(this CreatePedidoModel pedidoModel) =>
            new Pedido(0, pedidoModel.Pedido, pedidoModel.Itens, pedidoModel.PedidoExistente);

        public static IEnumerable<PedidoModel> ConvertToPedidos(this IList<Pedido> pedidos) =>
            new List<PedidoModel>(pedidos.Select(s => new PedidoModel(s.Id)));

        public static PedidoModel ConvertToPedido(this Pedido pedido) =>
            new PedidoModel(pedido.Id, pedido.ValorTotalPedido, pedido.QuantidadeItensPedido, pedido.Itens);
    }
}
