using MercadoEletronico.Domain.Entities;
using System.Collections.Generic;

namespace MercadoEletronico.Domain.Interfaces
{
    public interface IRepositoryPedido
    {
        void Save(Pedido obj);

        void Remove(int id);

        Pedido GetById(int id);

        Pedido GetByPedido(string identificadorPedido);

        IList<Pedido> GetAll();
    }
}
