using AutoMapper;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class TagMapping : Profile
    {
        public TagMapping()
        {
            CreateMap<Tag, TagDto>()
                .ReverseMap();
        }
    }
}