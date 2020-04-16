using System.Collections.Generic;

namespace RestApiWorkshop.Api.TransferObjects
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}