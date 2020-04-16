using AutoMapper;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class BlogMapping : Profile
    {
        public BlogMapping()
        {
            CreateMap<Blog, BlogDto>()
                .ReverseMap();
        }
    }
}