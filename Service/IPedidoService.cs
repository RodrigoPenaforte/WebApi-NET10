

using WebApi_NET10.Models;

namespace WebApi_NET10.Service
{
    public interface IPedidoService
    {
        public Task<IEnumerable<Pedido>> BuscarTodosAsync();
        public Task<Pedido?> BuscarPorIdAsync(long id);
        public Task CriarPedido(Pedido pedido);
        public Task<bool> AtualizarPedido(Pedido pedido);
        public Task<bool> DeletarPedido(long id);
    }
}