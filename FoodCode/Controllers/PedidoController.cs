using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Enums;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] Pedido pedido)
        {
            if (pedido.Itens == null || !pedido.Itens.Any())
            {
                return BadRequest("O pedido deve conter pelo menos um item.");
            }

            var pedidoCriado = await _pedidoService.CriarPedido(pedido.MesaId, pedido.Itens);

            return CreatedAtAction(nameof(ObterPedido), new { id = pedidoCriado.Id }, pedidoCriado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            var pedido = _pedidoService.ObterPedido(id);

            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(pedido);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarStatusPedido(int id, [FromQuery] StatusPedidoEnum status)
        {
            if (!Enum.IsDefined(typeof(StatusPedidoEnum), status))
            {
                return BadRequest("Status inválido.");
            }

            try
            {
                await _pedidoService.AtualizarStatusPedido(id, status);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar o status: {ex.Message}");
            }
        }
    }
}
