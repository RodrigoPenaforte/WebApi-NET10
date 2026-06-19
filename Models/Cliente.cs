using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_NET10.Models
{
    public class Cliente
    {
        public long Id { get; set; }
        public string Nome {get;set;}
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Collection<Pedido> Pedidos { get; set; }
    }
}