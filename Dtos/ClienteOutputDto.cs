using System.Collections.ObjectModel;
using WebApi_NET10.Models;

namespace WebApi_NET10.Dtos
{
    public class ClienteOutputDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Collection<PedidoOutputDto> Pedidos { get; set; }
    }
}