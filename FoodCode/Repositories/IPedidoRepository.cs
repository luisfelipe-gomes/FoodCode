using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetById(int id);
        Task<Pedido> Create(Pedido pedido);
        Task Update(Pedido pedido);
    }
}
