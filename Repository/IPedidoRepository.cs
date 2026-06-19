using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NET10.Models;

namespace WebApi_NET10.Repository
{
    public interface IPedidoRepository
    {
        public Task<IEnumerable<Pedido>> BuscarTodosAsync();
        public Task<Pedido?> BuscarPorIdAsync(long id);
        public Task CriarPedido(Pedido pedido);
        public Task AtualizarPedido(Pedido pedido);
        public Task DeletarPedido(Pedido pedido);
        public Task<bool> SalvarAsync();
    }
}