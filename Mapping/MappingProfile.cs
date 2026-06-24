using AutoMapper;
using WebApi_NET10.Dtos;
using WebApi_NET10.Models;

namespace WebApi_NET10.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteOutputDto>().ReverseMap();
            CreateMap<Cliente, ClienteInputDto>().ReverseMap();

            CreateMap<Pedido, PedidoOutputDto>().ForMember(destino => destino.NomeCliente, origem => origem.MapFrom(pedido => pedido.Cliente.Nome)).ReverseMap();
            CreateMap<Pedido,PedidoInputDto>().ReverseMap();
        }
    }
}