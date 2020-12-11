using MercadoEletronico.Domain.Entities;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Models.Pedido
{
    public class CreatePedidoModel
    {
        public int Id { get; set; }
        public string Pedido { get; set; }
        public ICollection<Item> Itens { get; set; }
        public bool PedidoExistente { get; set; }
    }
}
