using AutoMapper;
using SolidariusAPI.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.TransferObjects
{
    public class NotificacaoMapping : Profile
    {
        public NotificacaoMapping()
        {
            CreateMap<Notificacao, NotificacaoDto>()
                .ReverseMap();
        }
    }
}
