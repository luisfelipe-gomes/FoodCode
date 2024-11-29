using WebAPI.Enums;
namespace WebAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public StatusPedidoEnum Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
