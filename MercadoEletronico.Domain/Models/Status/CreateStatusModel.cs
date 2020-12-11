namespace MercadoEletronico.Domain.Models.Status
{
    public class CreateStatusModel
    {
        public string Status { get; set; }
        public int ItensAprovados { get; set; }
        public decimal ValorAprovado { get; set; }
        public string Pedido { get; set; }
    }
}
