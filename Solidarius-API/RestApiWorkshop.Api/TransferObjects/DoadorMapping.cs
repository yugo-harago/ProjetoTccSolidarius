using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SolidariusAPI.Api.Models;

namespace SolidariusAPI.Api.TransferObjects
{
    public class DoadorMapping : Profile
    {
        public DoadorMapping()
        {
            CreateMap<Doador, DoadorDto>()
                .ReverseMap();
        }
    }
}
