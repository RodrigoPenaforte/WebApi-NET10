using WebApi_NET10.Models;

namespace WebApi_NET10.Service
{
    public interface IClienteService
    {
        public Task<IEnumerable<Cliente>> BuscarTodosAsync();
        public Task<Cliente?> BuscarPorIdAsync(long id);
        public Task CriarCliente(Cliente cliente);
        public Task<bool> AtualizarCliente(Cliente cliente);
        public Task<bool> DeletarCliente(long id);
    }
}