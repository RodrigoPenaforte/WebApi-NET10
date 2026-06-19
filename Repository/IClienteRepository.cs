using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NET10.Models;

namespace WebApi_NET10.Repository
{
    public interface IClienteRepository
    {
        public Task<IEnumerable<Cliente>> BuscarTodosAsync();
        public Task<Cliente?> BuscarPorIdAsync(long id);
        public Task CriarCliente(Cliente cliente);
        public Task AtualizarCliente(Cliente cliente);
        public Task DeletarCliente(Cliente cliente );
        public Task<bool> SalvarAsync();
    }
}