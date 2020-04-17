using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SolidariusAPI.Api.Models;

namespace SolidariusAPI.Api.TransferObjects
{
    public class PedidoMapping : Profile
    {
        public PedidoMapping()
        {
            CreateMap<Pedido, PedidoDto>()
                .ReverseMap();
        }
    }
}
