using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MercadoEletronico.Domain.Entities
{
    public class Pedido : BaseEntity<int>
    {
        public Pedido(int id, string codigoPedido, IEnumerable<Item> itens, bool pedidoExistente) : base(id)
        {
            if (codigoPedido.Trim().Length == 0)
                AddNotification("CodigoPedido", "Informe o código do pedido.");

            if (pedidoExistente)
                AddNotification("PedidoExistente", "O número do pedido informado já existe.");

            if (itens.Count() == 0)
                AddNotification("Itens", "Informe pelo menos um item.");

            if (Valid)
            {
                Id = id;
                CodigoPedido = codigoPedido;
                Itens = itens;
            }
        }

        protected Pedido() { }

        public string CodigoPedido { get; set;}

        public virtual IEnumerable<Item> Itens { get; set; }
        
        [NotMapped]
        public decimal ValorTotalPedido => Itens.Sum(i => i.PrecoUnitario * i.Qtd);

        [NotMapped]
        public int QuantidadeItensPedido => Itens.Sum(i => i.Qtd);
    }
}

