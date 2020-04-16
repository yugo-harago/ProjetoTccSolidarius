using AutoMapper;
using RestApiWorkshop.Api.Models;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class AuthorMapping : Profile
    {
        public AuthorMapping()
        {
            CreateMap<Author, AuthorDto>()
                .ReverseMap();
        }
    }
}