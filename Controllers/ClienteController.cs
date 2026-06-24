using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using WebApi_NET10.Dtos;
using WebApi_NET10.Models;
using WebApi_NET10.Service;

namespace WebApi_NET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteOutputDto>>> BuscarTodos()
        {
            var clientes = await _clienteService.BuscarTodosAsync();
            return Ok(_mapper.Map<IEnumerable<ClienteOutputDto>>(clientes));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteOutputDto>> BuscarPorId(long id)
        {
            var cliente = await _clienteService.BuscarPorIdAsync(id);
            return Ok(_mapper.Map<ClienteOutputDto>(cliente));

        }

        [HttpPost]
        public async Task<ActionResult<ClienteOutputDto>> Criar(ClienteInputDto clienteInputDto)
        {
            var clienteMapeado = _mapper.Map<Cliente>(clienteInputDto);

            var cliente = await _clienteService.CriarCliente(clienteMapeado);

            if (cliente is null)
            {
                return BadRequest("Usuário não criado...");
            }

            var output = _mapper.Map<ClienteOutputDto>(cliente);


            return CreatedAtAction(nameof(BuscarPorId), new { id = output.Id }, output);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteOutputDto>> Atualizar(long id, ClienteInputDto clienteInputDto)
        {

            var clienteExiste = await _clienteService.BuscarPorIdAsync(id);

            if (clienteExiste is null)
                return NotFound();

            _mapper.Map(clienteInputDto, clienteExiste);

            await _clienteService.AtualizarCliente(clienteExiste);

            var clienteMapeado = _mapper.Map<ClienteOutputDto>(clienteExiste);

            return Ok(clienteMapeado);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteOutputDto>> Deletar(long id)
        {
            var clienteDeletado = await _clienteService.DeletarCliente(id);

            if (!clienteDeletado)
                return NotFound();

            return NoContent();
        }

    }
}