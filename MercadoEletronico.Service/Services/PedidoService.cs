using Infra.Shared.Contexts;
using Infra.Shared.Mapper;
using MercadoEletronico.Domain.Interfaces;
using MercadoEletronico.Domain.Models.Pedido;
using System.Collections.Generic;

namespace MercadoEletronico.Service.Services
{
    public class PedidoService : IServicePedido
    {
        private readonly IRepositoryPedido _repositoryPedido;
        private readonly NotificationContext _notificationContext;

        public PedidoService(IRepositoryPedido repositoryPedido, NotificationContext notificationContext)
        {
            _repositoryPedido = repositoryPedido;
            _notificationContext = notificationContext;
        }

        public IEnumerable<PedidoModel> RecoverAll()
        {
            var pedidos = _repositoryPedido.GetAll();
            return pedidos.ConvertToPedidos();
        }

        public PedidoModel Insert(CreatePedidoModel pedidoModel)
        {
            var pedido = pedidoModel.ConvertToPedidoEntity();
            _notificationContext.AddNotifications(pedido.Notifications);

            if (_notificationContext.Invalid)
                return default;

            _repositoryPedido.Save(pedido);
            return pedido.ConvertToPedido();
        }

        public PedidoModel RecoverById(int id)
        {
            var pedido = _repositoryPedido.GetById(id);
            if (pedido == null)
                return new PedidoModel(0);

            return pedido.ConvertToPedido();
        }

        public PedidoModel RecoverByPedido(string identificadorPedido)
        {
            var pedido = _repositoryPedido.GetByPedido(identificadorPedido);
            if (pedido == null)
                return new PedidoModel(0);

            return pedido.ConvertToPedido();
        }
    }
}
