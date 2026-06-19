using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi_NET10.Models;
using WebApi_NET10.Repository;

namespace WebApi_NET10.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> BuscarTodosAsync()
        {
            return await _clienteRepository.BuscarTodosAsync() ?? throw new BadHttpRequestException("Não foi possível achar o cliente");
        }
        public async Task<Cliente?> BuscarPorIdAsync(long id)
        {
            return await _clienteRepository.BuscarPorIdAsync(id) ?? throw new BadHttpRequestException("Id do cliente não foi encontrado");

        }

        public Task CriarCliente(Cliente cliente)
        {
            return _clienteRepository.CriarCliente(cliente) ?? throw new BadHttpRequestException("Não foi possível criar o cliente.");
        }
        public async Task<bool> AtualizarCliente(Cliente cliente)
        {

            var atualizarCliente = await _clienteRepository.BuscarPorIdAsync(cliente.Id);
            if (atualizarCliente is null) return false;

            await _clienteRepository.AtualizarCliente(atualizarCliente);
            return true;
        }

        public async Task<bool> DeletarCliente(long id)
        {
            var clienteDelete = await _clienteRepository.BuscarPorIdAsync(id);
            if (clienteDelete is null) return false;

            await _clienteRepository.DeletarCliente(clienteDelete);
            return true;
        }
    }
}