using WebAPI.Models;
using WebAPI.Enums;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterPedido(int id)
        {
            return await _pedidoRepository.GetById(id);
        }

        public async Task<Pedido> CriarPedido(int mesaId, List<ItemPedido> Itens)
        {
            var pedido = new Pedido
            {
                MesaId = mesaId,
                Itens = Itens,
                Status = StatusPedidoEnum.Pendente,
                DataCriacao = DateTime.Now
            };

            return await _pedidoRepository.Create(pedido);
        }

        public async Task AtualizarStatusPedido(int pedidoId, StatusPedidoEnum status)
        {
            var pedido = await _pedidoRepository.GetById(pedidoId);

            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado.");
            }

            pedido.Status = status;
            await _pedidoRepository.Update(pedido);
        }
    }
}
