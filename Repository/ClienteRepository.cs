using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApi_NET10.Data;
using WebApi_NET10.Models;

namespace WebApi_NET10.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
            => await _context.Clientes.Include(c => c.Pedidos).ToListAsync();

        public async Task<Cliente?> BuscarPorIdAsync(long id)
            => await _context.Clientes
                    .Include(p => p.Pedidos)
                    .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<Cliente> CriarCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }
        public async Task AtualizarCliente(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await SalvarAsync();
        }

        public async Task DeletarCliente(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await SalvarAsync();
        }


        public async Task<bool> SalvarAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}