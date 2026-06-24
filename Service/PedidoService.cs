using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_NET10.Models;
using WebApi_NET10.Repository;

namespace WebApi_NET10.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<IEnumerable<Pedido>> BuscarTodosAsync()
        {
            return await _pedidoRepository.BuscarTodosAsync() ?? throw new BadHttpRequestException("Não foi encontrado nenhum pedido...");
        }
        public async Task<Pedido?> BuscarPorIdAsync(long id)
        {
            return await _pedidoRepository.BuscarPorIdAsync(id) ?? throw new BadHttpRequestException("Não foi encontrado o pedido...");
        }

        public async Task CriarPedido(Pedido pedido)
        {
            pedido.Data = DateTime.UtcNow;
            await _pedidoRepository.CriarPedido(pedido);
        }
        public async Task<bool> AtualizarPedido(Pedido pedido)
        {
            var pedidoExistente = await _pedidoRepository.BuscarPorIdAsync(pedido.Id);
            if (pedidoExistente is null) return false;

            await _pedidoRepository.AtualizarPedido(pedidoExistente);
            return true;

        }
        public async Task<bool> DeletarPedido(long id)
        {
            var pedidoDeletar = await _pedidoRepository.BuscarPorIdAsync(id);
            if (pedidoDeletar is null) return false;

            await _pedidoRepository.DeletarPedido(pedidoDeletar);
            return true;
        }
    }
}