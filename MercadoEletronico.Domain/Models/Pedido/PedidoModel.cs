using MercadoEletronico.Domain.Entities;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Models.Pedido
{
    public class PedidoModel
    {
        public PedidoModel(int id)
        {
            Id = id;
        }

        public PedidoModel(int id, decimal valorTotalPedido, int quantidadeItensPedido, IEnumerable<Item> itens)
        {
            Id = id;
            Itens = itens;
            ValorTotalPedido = valorTotalPedido;
            QuantidadeItensPedido = quantidadeItensPedido;
        }

        public int Id { get; set; }
        public decimal ValorTotalPedido { get; set; }
        public int QuantidadeItensPedido { get; set; }
        public IEnumerable<Item> Itens { get; set; }
    }
}
