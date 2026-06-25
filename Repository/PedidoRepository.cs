using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi_NET10.Data;
using WebApi_NET10.Models;

namespace WebApi_NET10.Repository
{
    public class PedidoRepository : IPedidoRepository
    {

        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> BuscarTodosAsync()
         => await _context.Pedidos.Include(c => c.Cliente).ToListAsync();

        public async Task<Pedido?> BuscarPorIdAsync(long id)
         => await _context.Pedidos.Include(c => c.Cliente).FirstOrDefaultAsync(i => i.Id == id);

        public async Task<Pedido> CriarPedido(Pedido pedido)
        {
            await _context.AddAsync(pedido);
            await SalvarAsync();
            
            return pedido;
        }
        public async Task AtualizarPedido(Pedido pedido)
        {
            _context.Update(pedido);
            await SalvarAsync();
        }

        public async Task DeletarPedido(Pedido pedido)
        {
            _context.Remove(pedido);
            await SalvarAsync();
        }

        public async Task<bool> SalvarAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}