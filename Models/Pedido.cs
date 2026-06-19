using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_NET10.Models
{
    public class Pedido
    {
        public long Id { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public string Status { get; set; }
    }
}