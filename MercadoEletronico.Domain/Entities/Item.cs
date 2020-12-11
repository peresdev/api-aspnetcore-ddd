namespace MercadoEletronico.Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        public Item(int id, string descricao, decimal precoUnitario, int qtd) : base(id)
        {
            if (descricao.Trim().Length == 0)
                AddNotification("Descrição", "Informe a descrição do item.");

            if (precoUnitario.Equals(null))
                AddNotification("Preço Unitário", "Informe o preço unitário do item.");

            if (qtd.Equals(0))
                AddNotification("Quantidade", "Informe a quantidade do item.");

            if (Valid)
            {
                Descricao = descricao;
                PrecoUnitario = precoUnitario;
                Qtd = qtd;
            }
        }

        protected Item() { }

        public string Descricao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Qtd { get; set;  }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}

