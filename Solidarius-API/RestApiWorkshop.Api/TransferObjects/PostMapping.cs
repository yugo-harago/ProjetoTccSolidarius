using AutoMapper;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class PostMapping : Profile
    {
        public PostMapping()
        {
            CreateMap<Post, PostDto>()
                .ReverseMap();
        }
    }
}