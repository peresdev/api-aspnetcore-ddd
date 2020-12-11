using System.Collections.Generic;
using MercadoEletronico.Domain.Models.Pedido;

namespace MercadoEletronico.Domain.Interfaces
{
    public interface IServicePedido
    {
        PedidoModel Insert(CreatePedidoModel pedidoModel);

        IEnumerable<PedidoModel> RecoverAll();

        PedidoModel RecoverById(int id);

        PedidoModel RecoverByPedido(string identificadorPedido);
    }
}
