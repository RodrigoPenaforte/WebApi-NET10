using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi_NET10.Dtos;
using WebApi_NET10.Models;
using WebApi_NET10.Service;

namespace WebApi_NET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly Mapper _mapper;

        private readonly IClienteService _clienteService;

        public PedidoController(IPedidoService pedidoService, Mapper mapper, IClienteService clienteService)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoOutputDto>>> BuscarTodosPedidos()
        {
            var pedidos = _pedidoService.BuscarTodosAsync();
            return Ok(_mapper.Map<IEnumerable<PedidoOutputDto>>(pedidos));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoOutputDto>> BuscarPedidosPorId(long id)
        {
            var pedido = await _pedidoService.BuscarPorIdAsync(id);
            if (pedido is null) return NotFound();

            return Ok(_mapper.Map<PedidoOutputDto>(pedido));
        }

        [HttpPost]
        public async Task<ActionResult<PedidoOutputDto>> CriarPedido(PedidoInputDto pedidoInputDto)
        {
            var clienteExiste = await _clienteService.BuscarPorIdAsync(pedidoInputDto.ClienteId);
            if (clienteExiste is null) return NotFound("Çliente não encontrado...");

            var pedidoMapeado = _mapper.Map<Pedido>(pedidoInputDto);
            var pedido = _pedidoService.CriarPedido(pedidoMapeado);
            var pedidoOutPut = _mapper.Map<PedidoOutputDto>(pedido);

            return CreatedAtAction(nameof(BuscarPedidosPorId), new { id = pedidoOutPut.Id }, pedidoOutPut);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoOutputDto>> Atualizar(long id, PedidoInputDto pedidoInputDto)
        {
            var pedidoExistente = await _pedidoService.BuscarPorIdAsync(id);
            if (pedidoExistente is null)
                return NotFound("Pedido não existe");

            _mapper.Map(pedidoInputDto, pedidoExistente);

            await _pedidoService.AtualizarPedido(pedidoExistente);

            var pedidoMapeadoParaUsuario = _mapper.Map<PedidoOutputDto>(pedidoExistente);

            return Ok(pedidoMapeadoParaUsuario);
        }

          [HttpDelete("{id}")]
        public async Task <ActionResult<PedidoOutputDto>> Deletar(long id)
        {
            var pedidoDeltado = await _pedidoService.DeletarPedido(id);
            
            if(!pedidoDeltado)
                return NotFound();

            return NoContent();
        }


    }
}