using MercadoEletronico.Domain.Entities;
using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronico.Infra.Data.Repository
{
    public class PedidoRepository : BaseRepository<Pedido, int>, IRepositoryPedido
    {
        public PedidoRepository(SqliteContext sqliteContext) : base(sqliteContext)
        {

        }

        public IList<Pedido> GetAll() => _sqliteContext.Set<Pedido>().Include(p => p.Itens).ToList();

        public Pedido GetById(int id) => 
            base.Select(id);

        public Pedido GetByPedido(string identificadorPedido) =>
            _sqliteContext.Set<Pedido>().Include(p => p.Itens).FirstOrDefault(p => p.CodigoPedido == identificadorPedido);

        public void Remove(int id) =>
            base.Delete(id);

        public void Save(Pedido obj)
        {
            if (obj.Id == 0)
                base.Insert(obj);
            else
                base.Update(obj, _sqliteContext.Entry(obj).Property(prop => prop.Id));
        }

    }
}
