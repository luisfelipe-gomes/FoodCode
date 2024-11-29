using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using WebAPI.DataContext;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDBContext _context;
        public PedidoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Pedido> Create(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _context.Pedidos.Include(p => p.Itens).ThenInclude(i => i.Produto)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Update(Pedido pedido)
        {
            _context.Update(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
