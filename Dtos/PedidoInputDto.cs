using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_NET10.Dtos
{
    public class PedidoInputDto
    {
        public long ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
    }
}