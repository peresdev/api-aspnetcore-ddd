using System.Collections.Generic;

namespace MercadoEletronico.Domain.Models.Status
{
    public class StatusResponseModel
    {
        public string Pedido { get; set; }
        public List<string> Status { get; set; }
    }
}
