using System.Collections.Generic;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class BlogDto
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public List<PostDto> Posts { get; set; } = new List<PostDto>();

        public AuthorDto Author { get; set; }
    }
}